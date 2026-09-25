using System.Reflection;
using Microsoft.Extensions.Configuration;
using Telnyx;

var configBuilder = new ConfigurationBuilder()
                        .AddEnvironmentVariables()
                        .AddUserSecrets(Assembly.GetExecutingAssembly());

var Configuration = configBuilder.Build();


var apiKey = Configuration["TELNYX_API_KEY"];
TelnyxConfiguration.SetApiBase("https://api.telnyx.com/v2");
TelnyxConfiguration.SetApiKey(apiKey);
TelnyxConfiguration.HttpMessageHandler = new LoggingHttpMessageHandler();
    
CallControl callControl = new CallControl(Configuration);

await callControl.Dial("+1**********"); // Use your own phone number