﻿namespace PostsApp.Views;

public partial class MainView
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
