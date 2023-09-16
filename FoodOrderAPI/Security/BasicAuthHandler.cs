﻿using System.Text;

namespace FoodOrderAPI.Security
{
    public class BasicAuthHandler
    {
        private readonly RequestDelegate next;
        private readonly string relm;

        public BasicAuthHandler(RequestDelegate next, string relm)
        {
            this.next = next;   
            this.relm = relm;   
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] uidpwd = creds.Split(":");
            var uid = uidpwd[0];    
            var pwd = uidpwd[1]; 
            if(uid != "testingapp" && pwd != "Bangsat12345")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            await next(context);
        }

    }
}
