using Microservice.Chatbot.Core.Dtos;
using Microservice.Chatbot.DataAccess.Entities;
using Microservice.Chatbot.DataAccess.Repository;
using Microservice.Chatbot.Helper;
using Pgvector;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microservice.Chatbot.Core.Logic
{
    public class ChatbotCore: IChatbotCore
    {
        private readonly IHttpChatbotRequest _requestHttp;
        private readonly IChatbotRepository _chatbotRepository;

        public ChatbotCore(IHttpChatbotRequest requestHttp, IChatbotRepository chatbotRepository)
        {
            _requestHttp = requestHttp;
            _chatbotRepository = chatbotRepository;
        }

        public async Task<string> SearchExplanation(string sentence)
        {
            var values = (await GetItemsByVector(sentence)).ToList();

            var context = values.Count == 0
                ? "No hay contexto recuperado."
                : string.Join("\n", values.Select(x => $"- {x.sentence}"));

            var prompt = "Eres un asistente de IA. Responde a la pregunta del usuario basándote únicamente en el contexto provisto. " +
                         "Si el contexto no tiene la respuesta, di que no lo sabes.\n\n" +
                         $"CONTEXTO RECUPERADO:\n{context}\n\n" +
                         $"PREGUNTA DEL USUARIO:\n{sentence}";

            var response = await _requestHttp.CallGenerateContentAPI(prompt);

            if (string.IsNullOrWhiteSpace(response))
            {
                throw new InvalidOperationException("La respuesta de generateContent no contiene texto.");
            }

            return response;
        }

        public async Task<IEnumerable<SearchCoseneItemView>> GetItemsByVector(string sentence)
        {
            var values = await _requestHttp.CallEmbeddingAPI(sentence);
            var vector = new Vector(values.ToArray()); // Aquí deberías convertir el plainText en un vector
            return await _chatbotRepository.GetItemsByVector(vector, 5);
        }

        public async Task<object> VectorizeAndSaveData(string plainText)
        {
            var sentences = UtilsHelper.SplitIntoSentences(plainText);
            if (sentences.Count == 0)
            {
                return new { processedSentences= 0, message = "No se encontraron oraciones válidas para procesar." };
            }

            var itemsToInsert = new List<Items>();

            for (var index = 0; index < sentences.Count; index++)
            {
                var sentence = sentences[index];
                
                var values = await _requestHttp.CallEmbeddingAPI(sentence);

                itemsToInsert.Add(new Items
                {
                    name = $"sentence_{index + 1}",
                    item_data = JsonSerializer.Serialize(new ItemDataModel { text = sentence }),
                    embedding = new Vector(values.ToArray())
                });
            }

            int dataSaved = await _chatbotRepository.SaveItems(itemsToInsert);
            return new { processedSentences= dataSaved, message = "Embeddings generados y guardados correctamente." };
        }
    }

}
