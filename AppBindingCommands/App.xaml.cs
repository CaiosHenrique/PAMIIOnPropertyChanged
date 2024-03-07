namespace AppBindingCommands
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DateTime data = DateTime.Now;
            Preferences.Set("dtAtual", data);
            Preferences.Set("AcaoInicial", $"App executado as: {data}. \n");



            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            Preferences.Set("AcaoStart", string.Format("$\"App iniciado as: {0}",DateTime.Now));
        }   

        protected override void OnSleep()
        {
            base.OnSleep();
            Preferences.Set("AcaoSleep", string.Format("$\"App em segundo plano as: {0}",DateTime.Now));
        }
        protected override void OnResume()
        {
            base.OnResume();
            Preferences.Set("AcaoResume", string.Format("$\"App reativado as: {0}",DateTime.Now));
        }
    }
}
