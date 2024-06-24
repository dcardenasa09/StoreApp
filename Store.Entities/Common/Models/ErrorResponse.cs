namespace Store.Entities.Common.Models;

public class ErrorResponse {
    public int Code { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public bool HasErrors { get; set; }
    public IDictionary<string, string[]> Errors { get; set; }
}