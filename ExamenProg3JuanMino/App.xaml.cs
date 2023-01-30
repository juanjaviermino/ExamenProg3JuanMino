using ExamenProg3JuanMino.Data;
using ExamenProg3JuanMino.Services;

namespace ExamenProg3JuanMino;

public partial class App : Application
{
    public static DataActions Repositorio { get; private set; }
    public static ImageGenerator API { get; private set; } 

    public App(DataActions repo, ImageGenerator api)
	{
		InitializeComponent();

		MainPage = new AppShell();

        Repositorio = repo;
        API = api;
    }
}
