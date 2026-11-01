using Microservice.Chatbot.Core.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Chatbot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        private readonly IChatbotCore _chatbotCore;

        public ChatbotController(IChatbotCore chatbotCore)
        {
            _chatbotCore = chatbotCore;
        }

        [HttpPost("search-explanation")]
        public async Task<IActionResult> SearchExplanation(string? plainText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(plainText))
                {
                    using var reader = new StreamReader(Request.Body);
                    plainText = await reader.ReadToEndAsync();
                }

                if (string.IsNullOrWhiteSpace(plainText))
                {
                    return BadRequest("El texto no puede estar vacío.");
                }
                var response = await _chatbotCore.SearchExplanation(plainText);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Error en la operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/Chatbot
        [HttpPost("get-items-by-vector")]
        public async Task<IActionResult> GetItemsByVector(string? plainText)
        {
            try { 
                if (string.IsNullOrWhiteSpace(plainText))
                {
                    using var reader = new StreamReader(Request.Body);
                    plainText = await reader.ReadToEndAsync();
                }

                if (string.IsNullOrWhiteSpace(plainText))
                {
                    return BadRequest("El texto no puede estar vacío.");
                }
                var items = await _chatbotCore.GetItemsByVector(plainText);
                return Ok(items);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Error en la operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Chatbot/vectorize
        [HttpPost("vectorize")]
        public async Task<IActionResult> VectorizeAndSave(string? plainText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(plainText))
                {
                    using var reader = new StreamReader(Request.Body);
                    plainText = await reader.ReadToEndAsync();
                }

                if (string.IsNullOrWhiteSpace(plainText))
                {
                    return BadRequest("El texto no puede estar vacío.");
                }

                dynamic result = await _chatbotCore.VectorizeAndSaveData(plainText);

                if (result.processedSentences == 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Error en la operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


    }
}
