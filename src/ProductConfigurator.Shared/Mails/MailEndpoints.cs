using System;

namespace ProductConfigurator.Shared
{
    public static class MailEndpoints
    {
        public const string Base = "api/mail";
        public static string Ping = $"{Base}/ping";
    }
}
