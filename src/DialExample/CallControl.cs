using Microsoft.Extensions.Configuration;
using Telnyx;
using Telnyx.net.Services.Calls.CallCommands;

public class CallControl(IConfiguration configuration)
{
    private readonly CallControlService callControlService = new CallControlService();
    private readonly string connectionId = configuration["TELNYX_CONNECTION_ID"] 
        ?? throw new InvalidOperationException("TELNYX_CONNECTION_ID environment variable is not set.");
    private readonly string sipUsername = configuration["TELNYX_SIP_USERNAME"] 
        ?? throw new InvalidOperationException("TELNYX_SIP_USERNAME environment variable is not set.");
    private readonly string sipPassword = configuration["TELNYX_SIP_PASSWORD"] 
        ?? throw new InvalidOperationException("TELNYX_SIP_PASSWORD environment variable is not set.");

    public async Task<CallDialResponse> Dial(string to)
    {
        var dialOptions = new CallControlDialOptions
        {
            AudioUrl = "https://us-east-1.telnyxcloudstorage.com/call-and-oates/rick.mp3",
            ConnectionId = this.connectionId,
            To = to,
            From = "+14445551212",
            TimeoutSecs = 30,
            TimeLimitSecs = 600,
            CommandId = Guid.NewGuid(),
            SipAuthUsername = this.sipUsername,
            SipAuthPassword = this.sipPassword,
            FromDisplayName = "HelloWorld",
            LinkTo = "agent-leg-cc",
            ExtraParams = new Dictionary<string,string>
            {
                ["supervisor_role"] = "monitor",
                ["bridge_intent"] = "true",
            }
        };

        var response = await this.callControlService.DialAsync(dialOptions);
        return response;
    }
}