﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialNetwork.Web.Configuration;
using System.Linq;

namespace SocialNetwork.Web
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityServer() 
				.AddDeveloperSigningCredential()
				.AddTestUsers(InMemoryConfiguration.Users().ToList())
				.AddInMemoryClients(InMemoryConfiguration.Clients())
				.AddInMemoryApiResources(InMemoryConfiguration.ApiResources());

		}
				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			app.UseDeveloperExceptionPage();

			app.UseIdentityServer();
		}
	}
}
