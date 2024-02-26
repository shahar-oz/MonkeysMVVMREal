using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("ShowMonkey", typeof(ShowMonkeyView));
        Routing.RegisterRoute("FindByLocation", typeof(FindMonkeyByLocationPage));
        Routing.RegisterRoute("MonkeysPage", typeof(MonkeysPage));

    }
}