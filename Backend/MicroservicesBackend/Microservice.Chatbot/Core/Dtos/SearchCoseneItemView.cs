namespace Microservice.Chatbot.Core.Dtos
{
    public class SearchCoseneItemView
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string sentence { get; set; } = string.Empty;
        public double distance { get; set; }
        public double similarity { get; set; }
    }
}
