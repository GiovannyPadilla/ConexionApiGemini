namespace ConexionApiGemini.Interface
{
    public interface IChatBotService
    {
        public Task<string> GetChatBotResponse(string prompt);
    }
}
