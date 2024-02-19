using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("MP" , typeof (MonkeysPage));
		Routing.RegisterRoute("FMBLP" , typeof (FindMonkeyByLocationPage));
		Routing.RegisterRoute("SMV" , typeof (ShowMonkeyView));
	}
}
