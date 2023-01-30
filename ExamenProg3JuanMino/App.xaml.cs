using ExamenProg3JuanMino.Data;

namespace ExamenProg3JuanMino;

public partial class App : Application
{
    public static DataActions Repositorio { get; private set; }
    //public static ImageGenerator API { get; private set; } //, ImageGenerator api

    public App(DataActions repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        Repositorio = repo;
        //API = api;
    }
}
