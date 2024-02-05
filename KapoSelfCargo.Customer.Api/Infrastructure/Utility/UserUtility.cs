namespace KapoSelfCargo.Customer.Api.Infrastructure.Utility
{
	public interface IUserUtility
	{
		string GetFirebaseUserId();
	}
	public class UserUtility : IUserUtility
	{
		private readonly HttpContext _httpContext;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public UserUtility(IHttpContextAccessor httpContextAccessor)
		{
			if (httpContextAccessor == null)
			{
				throw new ArgumentNullException(nameof(httpContextAccessor));
			}
			if (httpContextAccessor.HttpContext == null)
			{
				throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
			}
			_httpContext = httpContextAccessor.HttpContext;
			if (_httpContext == null)
			{
				return;
			}
		}
		public string GetFirebaseUserId()
		{
			var firebaseUser = _httpContext.User.Claims.FirstOrDefault(claim => claim.Type == "user_id");
			if (firebaseUser == null)
			{
				throw new Exception("Firebase user id not found");
			}
			if (string.IsNullOrEmpty(firebaseUser.Value))
			{
				throw new Exception("Firebase user id is empty");
			}
			return firebaseUser.Value;
		}
	}
}
