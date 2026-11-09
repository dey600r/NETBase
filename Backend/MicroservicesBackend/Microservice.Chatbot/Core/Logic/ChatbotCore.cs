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

        public async Task<string> SearchExplanation(string sentence, string type)
        {

            var values = GetItemsByVector(sentence, type).Result.ToList();

            var context = values.Count == 0
                ? "No hay contexto recuperado."
                : string.Join("\n", values.Select(x => $"- {x.sentence}"));

            var prompt = "Eres un asistente de IA. Responde a la pregunta del usuario basándote únicamente en el contexto provisto. " +
                         "Si el contexto no tiene la respuesta, di que no lo sabes.\n\n" +
                         $"CONTEXTO RECUPERADO:\n{context}\n\n" +
                         $"PREGUNTA DEL USUARIO:\n{sentence}";

            var response = type switch
            {
                "gemini" => await _requestHttp.CallGenerateContentGeminiAPI(prompt),
                "ollama" => await _requestHttp.CallGenerateContentOllamaAPI(prompt),
                _ => throw new ArgumentException("Tipo de embedding no soportado.", nameof(type))
            };

            if (string.IsNullOrWhiteSpace(response))
            {
                throw new InvalidOperationException("La respuesta de generateContent no contiene texto.");
            }

            return response;
        }

        public async Task<IEnumerable<SearchCoseneItemView>> GetItemsByVector(string sentence, string type)
        {
            return type switch
            {
                "gemini" => await GetItemsByVectorGemini(sentence),
                "ollama" => await GetItemsByVectorOllama(sentence),
                _ => throw new ArgumentException("Tipo de embedding no soportado.", nameof(type))
            };
        }

        public async Task<IEnumerable<SearchCoseneItemView>> GetItemsByVectorGemini(string sentence)
        {
            var values = await _requestHttp.CallEmbeddingGeminiAPI(sentence);
            var vector = new Vector(values.ToArray()); // Aquí deberías convertir el plainText en un vector
            return await _chatbotRepository.GetItemsByVectorGemini(vector, 5);
        }

        public async Task<IEnumerable<SearchCoseneItemView>> GetItemsByVectorOllama(string sentence)
        {
            var values = await _requestHttp.CallEmbeddingOllamaAPI(sentence);
            var vector = new Vector(values.ToArray()); // Aquí deberías convertir el plainText en un vector
            return await _chatbotRepository.GetItemsByVectorOllama(vector, 5);
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
                
                var valuesGemini = await _requestHttp.CallEmbeddingGeminiAPI(sentence);
                var valuesOllama = await _requestHttp.CallEmbeddingOllamaAPI(sentence);

                itemsToInsert.Add(new Items
                {
                    name = $"sentence_{index + 1}",
                    item_data = JsonSerializer.Serialize(new ItemDataModel { text = sentence }),
                    embedding = new Vector(valuesGemini.ToArray()),
                    embedding_small = new Vector(valuesOllama.ToArray())
                });
            }

            int dataSaved = await _chatbotRepository.SaveItems(itemsToInsert);
            return new { processedSentences= dataSaved, message = "Embeddings generados y guardados correctamente." };
        }
    }

}
