using Android.App;
using Android.Content;
using Android.Net;
using AppAuthExample.Droid;
using OpenId.AppAuth;
using System.Threading.Tasks;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(LoginProvider))]

namespace AppAuthExample.Droid
{
    public class LoginProvider : ILoginProvider
    {
        public async Task LoginAsync()
        {
            try
            {
                var authConfig = await AuthorizationServiceConfiguration.FetchFromIssuerAsync(Uri.Parse("https://example.com"));

                AuthState authState = new AuthState(authConfig);

                AuthorizationRequest.Builder authReqBuilder = new AuthorizationRequest.Builder(authConfig,
                                                                                               "RealOneGame.Xamarin",
                                                                                               ResponseTypeValues.Code,
                                                                                               Uri.Parse("https://com.example/oauth2redirect"));
                authReqBuilder.SetScope("api1 openid profile offline_access");

                AuthorizationRequest authReq = authReqBuilder.Build();

                AuthorizationService authService = new AuthorizationService(Application.Context);

                authService.PerformAuthorizationRequest(authReq, PendingIntent.GetActivity(Application.Context, 0, new Intent(Application.Context, typeof(MyAuthCompleteActivity)), 0),
                                                                 PendingIntent.GetActivity(Application.Context, 0, new Intent(Application.Context, typeof(MyAuthCanceledActivity)), 0));
            }
            catch
            {
            }
        }
    }
}