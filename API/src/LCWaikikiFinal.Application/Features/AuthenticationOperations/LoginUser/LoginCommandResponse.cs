﻿namespace LCWaikikiFinal.Application.Features.AuthenticationOperations
{
        public class LoginCommandResponse
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public bool IsSuccess { get; set; }
	}
}
