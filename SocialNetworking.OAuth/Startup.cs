using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialNetworking.OAuth.Congifuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;

namespace SocialNetworking.OAuth
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityServer()
					.AddSigningCredential(new X509Certificate2(@"C:\OpenSSL\socialnetwork.pfx", ""))
					.AddTestUsers(InMemoryConfiguration.Users().ToList())
					.AddInMemoryApiResources(InMemoryConfiguration.ApiResources())
					.AddInMemoryClients(InMemoryConfiguration.Clients());

			
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{

			loggerFactory.AddConsole();

			loggerFactory.AddDebug();


			app.UseDeveloperExceptionPage();

			app.UseIdentityServer();

			app.UseStaticFiles();

			app.UseMvcWithDefaultRoute();
		}
	}
}
