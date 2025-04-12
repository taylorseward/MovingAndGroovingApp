namespace MovingAndGroovingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Force light mode for the app
            Application.Current.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}