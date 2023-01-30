namespace ExamenProg3JuanMino;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NewImagePage), typeof(Views.NewImagePage));
        Routing.RegisterRoute(nameof(Views.GaleriaPage), typeof(Views.GaleriaPage));
    }
}
