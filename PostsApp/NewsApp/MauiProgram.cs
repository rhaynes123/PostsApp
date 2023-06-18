
global using System;
global using TinyMvvm;
global using Microsoft.Extensions.Logging;
global using PostsApp.Services;
global using PostsApp.ViewModels;
global using PostsApp.Views;
global using System.Collections.ObjectModel;
global using PostsApp.Models;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
namespace NewsApp;

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
			}).UseTinyMvvm();
		builder.Services.AddSingleton<IPostsService, PostsService>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<MainView>();

        builder.Services.AddTransient<PostViewModel>();
        builder.Services.AddTransient<PostView>();

		Routing.RegisterRoute(nameof(PostViewModel), typeof(PostView));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

