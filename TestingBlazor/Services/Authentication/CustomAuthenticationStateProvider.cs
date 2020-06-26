using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestingBlazor.Services.Authentication
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private string username;
		private string password;

		public void LoadUser(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		public async Task<AuthenticationState> Logout()
		{
			Clear();
			return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}

		public async override Task<AuthenticationState> GetAuthenticationStateAsync()
		{

			if (this.username == "teste@teste.com" && this.password == "123")
			{
				var identity = new ClaimsIdentity(
					new[] {
					new Claim(ClaimTypes.Name, this.username),
					}, "Own authentication Type");

				Clear();

				var authState = new AuthenticationState(new ClaimsPrincipal(identity));
				base.NotifyAuthenticationStateChanged(Task.FromResult(authState));
				return authState;
			}
			else
			{
				Clear();
				return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
			}

		}

		private void Clear()
		{
			this.username = null;
			this.password = null;
		}
	}
}
