namespace CameraWebViewApp;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private static async Task<bool> DoesDeviceHavePermissions()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.Camera>();
        }

        return status == PermissionStatus.Granted;
    }

    private static string VerifyInput(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            if (!url.Contains("://"))
            {
                url = "http://" + url;
            }
        }

        return url;
    }

    private async void OnGoButtonClicked(object sender, EventArgs e)
    {
        await HandleGoButtonClicked();
    }

    private async Task HandleGoButtonClicked()
    {
        var doesDeviceHavePermission = await DoesDeviceHavePermissions();
        var url = VerifyInput(urlEntry.Text);

        if (doesDeviceHavePermission)
        {
            inputLayout.IsVisible = false;
            webView.IsVisible = true;

            webView.Source = url;
        }
        else
        {
            await DisplayAlert("Error", "Device does not have Camera permissions", "OK");
        }
    }
}
