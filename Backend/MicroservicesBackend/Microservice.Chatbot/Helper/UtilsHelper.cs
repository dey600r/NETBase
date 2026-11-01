using System.Text.RegularExpressions;

namespace Microservice.Chatbot.Helper
{
    public static class UtilsHelper
    {
        private static readonly Regex SentenceSeparatorRegex = new(@"(?<=[.!?])\s+", RegexOptions.Compiled);

        public static List<string> SplitIntoSentences(string plainText)
        {
            return SentenceSeparatorRegex
                .Split(plainText)
                .Select(sentence => sentence.Trim())
                .Where(sentence => !string.IsNullOrWhiteSpace(sentence))
                .ToList();
        }
    }
}
