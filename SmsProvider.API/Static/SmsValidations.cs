namespace SmsProvider.API.Static
{
    public static class SmsValidations
    {
        public static bool CheckGreekCharacters(string input) => input.Where(character => char.IsLetter(character)).All(c => c >= '\u0370' && c <= '\u03FF');
        public static bool CheckSmsMaxCharacters(int length) => !((length == 0) || (length == 0) || (length > 480));
        public static IEnumerable<string> GetPartialMultipleSms(string message)
        {
            int length = message.Length;
            int maxLength = 160;

            var partial_messages = Enumerable
                    .Range(0, (length + maxLength - 1) / maxLength)
                    .Select(i => message.Substring(i * maxLength, Math.Min(maxLength, length - i * maxLength)));

            return partial_messages;
        }
    }
}
