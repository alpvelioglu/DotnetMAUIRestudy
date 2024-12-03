namespace HelloMaui;

class App : Application
{
    public App(AppShell shell)
    {
        Resources.MergedDictionaries.Add(new HelloMaui.Resources.Styles.Colors());
        Resources.MergedDictionaries.Add(new HelloMaui.Resources.Styles.Styles());

        MainPage = shell;
    }

    protected override void OnStart()
    {
        base.OnStart();
        
        Trace.WriteLine("*****App Started*****");
    }

    protected override void OnResume()
    {
        base.OnResume();
        
        Trace.WriteLine("*****App Resumed*****");
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        
        Trace.WriteLine("*****App Backgrounded*****");
    }
}
