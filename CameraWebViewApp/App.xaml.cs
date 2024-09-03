namespace CameraWebViewApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage();
            MainPage = new NavigationPage(mainPage);
        }
    }
}
