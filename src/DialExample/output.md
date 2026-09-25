```bash

Request: 

    Method: POST
    Request Uri: https://api.telnyx.com/v2/calls
    Headers: 
    Authorization=Bearer SOME_RANDOM_KEY_I_FOUND_ON_GITHUB,
  Telnyx-Version=2019-03-14,
  User-Agent=Telnyx/v1;.NetBindings/3.1.0,
  X-Telnyx-Client-User-Agent={"bindings_version":"3.1.0","lang":".net","publisher":"Telnyx","lang_version":".NET 10.0.8","os_version":"Ubuntu 26.04.1 LTS"}

    Body: 
    {"to":"+1**********","from":"+14445551212","","from_display_name":"HelloWorld","connection_id":"MY_CONNECTION_ID","audio_url":"https://us-east-1.telnyxcloudstorage.com/audio.mp3","timeout_secs":30,"time_limit_secs":600,"answering_machine_detection":"disabled","command_id":"dcf6fa68-e589-4956-85bd-0ce29e97390a","link_to":"agent-leg-cc","sip_auth_username":"mySipUsername","sip_auth_password":"mySipPassword","webhook_url_method":"POST","ExtraParams":{"supervisor_role":"monitor","bridge_intent":"true"}}<mark>&supervisor_role=monitor&bridge_intent=true</mark>


        
Request failed with status code: BadRequest
Unhandled exception. Telnyx.TelnyxException: {"errors":{"detail":"Bad Request"}}
   at Telnyx.Infrastructure.Requestor.ExecuteRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken) in src/Telnyx.net/Infrastructure/Requestor.cs:line 278
   at Telnyx.Infrastructure.Requestor.PostStringAsync(String url, RequestOptions requestOptions, CancellationToken cancellationToken) in src/Telnyx.net/Infrastructure/Requestor.cs:line 210
   at Telnyx.Service`1.PostRequestAsync[T](String url, BaseOptions options, RequestOptions requestOptions, Boolean isJsonResponse, String parentToken, CancellationToken cancellationToken) in src/Telnyx.net/Services/Service.cs:line 912
   at Telnyx.Service`1.CreateEntityAsync(BaseOptions options, RequestOptions requestOptions, String postBasePath, String parentToken, CancellationToken cancellationToken) in src/Telnyx.net/Services/Service.cs:line 173
   at Telnyx.CallControlDialService.CreateAsync(CallControlDialOptions createOptions, RequestOptions requestOptions, CancellationToken cancellationToken) in src/Telnyx.net/Services/Calls/CallControl/Dial/CallControlDialService.cs:line 41
   at Telnyx.net.Services.Calls.CallCommands.CallControlService.DialAsync(CallControlDialOptions options, RequestOptions requestOptions, CancellationToken ct) in src/Telnyx.net/Services/Calls/CallControl/CallControlService.cs:line 89
   at CallControl.Dial(String to) in src/DialExample/CallControl.cs:line 37
   at Program.<Main>$(String[] args) in src/DialExample/Program.cs:line 19
   at Program.<Main>(String[] args)

```