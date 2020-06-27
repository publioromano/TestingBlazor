using DevExpress.Blazor.Internal;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingBlazor.Services.Authentication
{
	public class LogoutProvider : ICommand
	{
		public CustomAuthenticationStateProvider CustomAuthenticationStateProvider { get; set ; }

		public bool CanExecute()
		{
			return CustomAuthenticationStateProvider.IsAuthenticated;
		}

		public AuthenticationState Execute()
		{
			return CustomAuthenticationStateProvider.Logout().Result;
		}
	}
}
