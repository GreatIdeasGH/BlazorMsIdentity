namespace BlazorMsIdentity.Shared
{
    public class AzureAdOptions
    {
        public const string AzureAd = "AzureAd";

        public string Instance { get; set; }
        public string Domain { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}