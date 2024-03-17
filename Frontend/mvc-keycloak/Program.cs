
using Keycloak.AuthServices.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer().AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    options.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("http://localhost:8180/realms/mvc/protocol/openid-connect/auth"),
                Scopes = new Dictionary<string, string>
                {
                    { "openid", "openid" },
                    { "profile", "profile" }
                }
            },
            ClientCredentials = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("http://localhost:8180/realms/mvc/protocol/openid-connect/auth"),
                Scopes = new Dictionary<string, string>
                {
                    { "openid", "openid" },
                    { "profile", "profile" }
                }
            }
        }
    });

    OpenApiSecurityScheme keycloakSecurityScheme = new()
    {
        Reference = new OpenApiReference
        {
            Id = "Keycloak",
            Type = ReferenceType.SecurityScheme,
        },
        In = ParameterLocation.Header,
        Name = "Bearer",
        Scheme = "Bearer",
    };

	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{ keycloakSecurityScheme, Array.Empty<string>() },
	});

	//var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	//var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	//options.IncludeXmlComments(xmlPath);
});

//builder.Services.AddKeycloakAuthentication(builder.Configuration);


builder.Services.AddAuthentication(options =>
{
	//Sets cookie authentication scheme
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(cookie =>
{
	//Sets the cookie name and maxage, so the cookie is invalidated.
	cookie.Cookie.Name = "keycloak.cookie";
	cookie.Cookie.MaxAge = TimeSpan.FromMinutes(60);
	cookie.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
	cookie.SlidingExpiration = true;
}).AddOpenIdConnect(options =>
{
	var config = builder.Configuration.GetSection("Keycloak");
	//Use default signin scheme
	options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	//Keycloak server
	options.Authority = config["auth-server-url"];
	//Keycloak client ID
	options.ClientId = config["resource"];
	//Keycloak client secret
	options.ClientSecret = config["client-secret"];
	options.UsePkce = false;

	//Keycloak .wellknown config origin to fetch config
	options.MetadataAddress = config["metadata"];
	//Require keycloak to use SSL
	options.RequireHttpsMetadata = false;
	options.GetClaimsFromUserInfoEndpoint = true;
	options.Scope.Add("openid");
	options.Scope.Add("profile");
	options.Scope.Add("email");

	//Save the token
	options.SaveTokens = true;
	//Token response type, will sometimes need to be changed to IdToken, depending on config.
	options.ResponseType = OpenIdConnectResponseType.Code;
	//SameSite is needed for Chrome/Firefox, as they will give http error 500 back, if not set to unspecified.
	options.NonceCookie.SameSite = SameSiteMode.None;
	options.CorrelationCookie.SameSite = SameSiteMode.None;

	options.TokenValidationParameters = new TokenValidationParameters
	{
		NameClaimType = ClaimTypes.Name,
		RoleClaimType = ClaimTypes.Role,
		ValidateIssuer = true,
		ValidateAudience = true,
	};

	options.CallbackPath = "/Callback/LoginCallback";

    //options.CallbackPath = "/signin-oidc"; // Set the callback path
    options.SignedOutCallbackPath = "/signout-callback-oidc"; // Set the signout callback path

    //builder.Configuration.Bind("<Json Config Filter>", options);
	//options.Events.OnRedirectToIdentityProvider = async context =>
	//{
	//	context.ProtocolMessage.RedirectUri = "https://localhost:44376/home";
	//	//context.ProtocolMessage.RedirectUri = "http://localhost:61580/home";
	//	await Task.FromResult(0);
	//};

    options.Events = new OpenIdConnectEvents
    {
        OnAuthorizationCodeReceived = context =>
        {
            // short lived code used to authorise the application on back channel
            return Task.CompletedTask;
        },
        OnRedirectToIdentityProvider = async context =>
        {
            //save url to state
            //  n.ProtocolMessage.State = n.HttpContext.Request.Path.Value.ToString();
            context.ProtocolMessage.RedirectUri = "https://localhost:44376/Callback/LoginCallback";
            //context.ProtocolMessage.RedirectUri = "http://localhost:61580/home";
            await Task.FromResult(0);
        },
        OnTokenValidated = context =>
        {

            return Task.CompletedTask;
        },
        OnTicketReceived = context =>
        {
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            context.Response.Redirect("/Home/Error?errormessage = " + context.Exception.Message);
            // context.HandleResponse(); // Suppress the exception
            return Task.CompletedTask;
        },
        OnRemoteFailure = context =>
        {
            context.Response.Redirect("/Home/Error");
            context.HandleResponse();
            return Task.FromResult(0);
        },
        OnSignedOutCallbackRedirect = context =>
        {
            context.Response.Redirect(context.Options.SignedOutRedirectUri);
            context.HandleResponse();

            return Task.CompletedTask;
        }
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "cors-rule", rule =>
    {
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseSwagger().UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.OAuthClientId("frontend");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


//// Add routes for callback handling
app.Map("/Callback/LoginCallback", signinApp =>
{
    signinApp.Run(async context =>
    {
        // Handle the callback from Keycloak after successful authentication
        await context.Response.WriteAsync("Authentication successful");
    });
});

//// Add routes for callback handling
//app.Map("/signin-oidc", signinApp =>
//{
//    signinApp.Run(async context =>
//    {
//        // Handle the callback from Keycloak after successful authentication
//        await context.Response.WriteAsync("Authentication successful");
//    });
//});

app.Map("/signout-callback-oidc", signoutApp =>
{
	signoutApp.Run(async context =>
	{
		// Handle the callback from Keycloak after sign-out
		await context.Response.WriteAsync("Sign-out successful");
	});
});

//app.MapGet("/", (ClaimsPrincipal user) =>
//{
//	app.Logger.LogInformation(user.Identity.Name);
//}).RequireAuthorization();


app.UseCors("cors-rule");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "login-callback",
        pattern: "login-callback",
        defaults: new { controller = "Callback", action = "LoginCallback" });

app.Run();
