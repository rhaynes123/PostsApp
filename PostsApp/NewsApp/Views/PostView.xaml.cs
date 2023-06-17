namespace PostsApp.Views;

public partial class PostView : ContentPage
{
	public PostView(PostViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
