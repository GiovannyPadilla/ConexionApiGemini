using ConexionApiGemini.Interface;
using ConexionApiGemini.Models;
using System.Net.Http;

namespace ConexionApiGemini.Repository
{
    public class GeminiRepository : IChatBotService
    {
        HttpClient _httpClient;
        private string apiKey = "AIzaSyC3Dn-AtpKVipjI9lY8xw5QuTPtUeN2WiE";
        public GeminiRepository()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetChatBotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);

            GeminiRequest request = new GeminiRequest
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        parts = new List<Part>
                        {
                            new Part
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };
            message.Content = JsonContent.Create<GeminiRequest>(request);
            var response = await _httpClient.SendAsync(message);
            string answer = await response.Content.ReadAsStringAsync();
            return answer;
        }
    }
}
