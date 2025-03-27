using Firebase.Auth;
using Firebase.Auth.Providers;
using MauiIcons.Material;
using Microsoft.Extensions.Logging;
using mobile_exam.Models;
using mobile_exam.Services;
using mobile_exam.Views;

namespace mobile_exam;

public static class MauiProgram
{
	public static IServiceProvider ServiceProvider { get; set; }
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Lato-Bold.ttf", "bold");
                fonts.AddFont("Lato-BoldItalic.ttf", "italic");
                fonts.AddFont("Lato-Regular.ttf", "regular");
                fonts.AddFont("Lato-Regular.ttf", "regular");
                fonts.AddFont("MauiMaterialAssets.ttf", "MaterialAssets");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
		{
			ApiKey= "",
			AuthDomain= "",
			Providers=
            [
                new EmailProvider()
			]
		}));
		builder.Services.AddSingleton<LoginView>();
		builder.Services.AddSingleton<SignInModelView>();
        builder.Services.AddSingleton<HomeView>();
        builder.Services.AddScoped<VeterinaryService>();
        builder.Services.AddScoped<RegisterService>();
        builder.Services.AddScoped(sp => new HttpClient
		{
			BaseAddress = new Uri("http://mauiappgab.somee.com/")
		});
        ServiceProvider = builder.Services.BuildServiceProvider();
		return builder.Build();
	}
}
