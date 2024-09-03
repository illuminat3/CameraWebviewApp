#if ANDROID
using Android.Webkit;

namespace CameraWebViewApp.Clients;

public class AndroidChromeClient : WebChromeClient
{
    public override void OnPermissionRequest(PermissionRequest? request)
    {
        if (request == null || request.GetResources() == null) return;

        foreach (var resource in request.GetResources()!)
        {

            if (resource.Equals(PermissionRequest.ResourceVideoCapture, StringComparison.OrdinalIgnoreCase))
            {
                request.Grant(request.GetResources());
                return;
            }
        }

        base.OnPermissionRequest(request);
    }
}
#endif
