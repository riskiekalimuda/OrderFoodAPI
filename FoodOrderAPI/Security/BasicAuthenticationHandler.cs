﻿using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace FoodOrderAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Headers.ContainsKey("Authorization"))
            {
                var headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(headerValue.Parameter);
                var credentials = Encoding.UTF8.GetString(bytes);
                if (!string.IsNullOrEmpty(credentials))
                {
                    string[] array = credentials.Split(":");
                    string username = array[0];
                    string password = array[1];
                    if (string.IsNullOrEmpty(username))
                        return AuthenticateResult.Fail("UnAuthorized");

                    if (username.Equals("testingapp") && password.Equals("Bangsat12345"))
                    {
                        var claim = new[] { (new Claim(ClaimTypes.Name, username)) };
                        var identity = new ClaimsIdentity(claim, Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);
                        return AuthenticateResult.Success(ticket);

                    }
                    else
                        return AuthenticateResult.Fail("UnAuthorized");

                }
                return AuthenticateResult.Fail("");
            }
            else
                return AuthenticateResult.Fail("");
            
        }
        
    }
}
