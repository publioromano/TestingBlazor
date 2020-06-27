using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingBlazor.Services.Authentication
{
	public interface ICommand
	{
		CustomAuthenticationStateProvider CustomAuthenticationStateProvider { get; set; }

		AuthenticationState Execute();

		bool CanExecute();
	}
}
