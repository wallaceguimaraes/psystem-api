namespace api.Authorization
{
    public class AuthOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Key { get; set; }
        public string? Secret { get; set; }
        public string? WebhookSecret { get; set; }
        public string? Issuer2FA { get; set; }
        public string? Audience2FA { get; set; }
        public string? Key2FA { get; set; }
        public int Expire2FA { get; set; }
        public int ExpireTokenIn { get; set; }
        public AuthCodeOptions? AuthCode { get; set; }
        public Dictionary<string, string[]> IpSafelist { get; set; } = new Dictionary<string, string[]>();
        public bool? DisableIpSafelistCheck { get; set; } = true;
        public bool DisableIpSafelistLog { get; set; }
    }
}