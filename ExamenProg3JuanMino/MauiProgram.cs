using ExamenProg3JuanMino.Data;
using ExamenProg3JuanMino.Services;

namespace ExamenProg3JuanMino;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = FileAccessHelper.GetLocalFilePath("burger.db3");
        builder.Services.AddSingleton<DataActions>(s => ActivatorUtilities.CreateInstance<DataActions>(s, dbPath));
        builder.Services.AddSingleton<ImageGenerator>(s => ActivatorUtilities.CreateInstance<ImageGenerator>(s));
        return builder.Build();
	}
}
