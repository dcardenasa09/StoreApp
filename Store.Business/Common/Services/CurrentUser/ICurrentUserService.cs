namespace Store.Business.Common.Services.CurrentUser;

public interface ICurrentUserService {
	public string? UserId { get; }
	public string? Token { get; }
}