using Android.App;
using Android.OS;
using OpenId.AppAuth;

namespace AppAuthExample.Droid
{
    public class MyAuthCompleteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AuthorizationResponse resp = AuthorizationResponse.FromIntent(Intent);
            AuthorizationException ex = AuthorizationException.FromIntent(Intent);

            base.OnCreate(savedInstanceState);
        }
    }
}