using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;

namespace TestingBlazor.Services.Authentication
{
	public class AuthenticationCommandService
	{
		private ICommand _loginProvider;
		private ICommand _logoutProvider;

		public AuthenticationCommandService()
		{
			this._loginProvider = new LoginProvider();
			this._logoutProvider = new LogoutProvider();

			this.Commands = new List<ICommand>();
			this.Commands.Add(_loginProvider);
			this.Commands.Add(_logoutProvider);
		}

		protected List<ICommand> Commands {get;private set;}

		public AuthenticationState Execute(CustomAuthenticationStateProvider customAuthenticationStateProvider)
		{
			foreach (var command in this.Commands)
			{
				command.CustomAuthenticationStateProvider = customAuthenticationStateProvider;
				if (command.CanExecute())
					return command.Execute();
			}
			return null;
		}
	}
}
