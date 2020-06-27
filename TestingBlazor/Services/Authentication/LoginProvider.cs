using DevExpress.Blazor.Internal;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace TestingBlazor.Services.Authentication
{
	public class LoginProvider : ICommand
	{
		public CustomAuthenticationStateProvider CustomAuthenticationStateProvider { get; set; }

		public bool CanExecute()
		{
			return !CustomAuthenticationStateProvider.IsAuthenticated;
		}

		public AuthenticationState Execute()
		{
			return CustomAuthenticationStateProvider.GetAuthenticationStateAsync().Result;
		}
	}
}
