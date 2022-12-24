namespace System
{
    public static class StringExtensions
    {
        public static string Cut(this string text, int limit)
        {
            if (text is null)
            {
                return "";
            }
            return text.Trim().Length > limit ? text.Trim()[..limit] : text.Trim();
        }
    }
}
