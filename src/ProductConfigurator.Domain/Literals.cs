namespace ProductConfigurator.Domain
{
    public static class Literals
    {
        public const string SendingOrder = "Sending request...";
        public const string OrderSentTitle = "The order was succesfully sent :)";
        public static string OrderSentSubtitle(string from)
            => $"You will receive an email from {from} with the details within 24 hours";
    }
}
