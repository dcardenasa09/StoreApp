namespace Store.Entities.Common.Models;

public class AppSettings {
    public string? Secret { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
}