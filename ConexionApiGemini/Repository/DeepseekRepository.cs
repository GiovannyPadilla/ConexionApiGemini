using ConexionApiGemini.Interface;

namespace ConexionApiGemini.Repository
{
    public class DeepseekRepository : IChatBotService
    {
        public async Task<string> GetChatBotResponse(string prompt)
        {
         return "Este es un string de Deepseek";
        }
    }

}
