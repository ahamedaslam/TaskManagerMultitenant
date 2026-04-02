
namespace TaskManager.Helper
{
    public class CleanAi
    {
        public static string CleanAiText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // ✅ If JSON → don't touch it
            if (IsJson(text))
                return text;

            // Only clean plain text
            return text
                .Replace("\r\n", " ")
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Replace("**", "")
                .Replace("###", "")
                .Replace("##", "")
                .Replace("#", "")
                .Trim();
        }

        public static bool IsJson(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            text = text.Trim();

            return (text.StartsWith("{") && text.EndsWith("}")) ||
                   (text.StartsWith("[") && text.EndsWith("]"));
        }


    }


}
