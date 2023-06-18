namespace PostsApp.Views;

public partial class PostView
{
	public PostView(PostViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
