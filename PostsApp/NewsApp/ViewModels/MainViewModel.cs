namespace PostsApp.ViewModels
{
	public partial class MainViewModel: ViewModel
	{
		private readonly IPostsService _newsService;
		public MainViewModel(IPostsService newsService)
		{
			_newsService = newsService;
			open = new AsyncRelayCommand<Post>(OpenPostView);
		}

		[ObservableProperty]
		private ObservableCollection<Post> posts = new();

		[ObservableProperty]
		private AsyncRelayCommand<Post> open;
        public override async Task Initialize()
        {
            await base.Initialize();

			try
			{
				IsBusy = true;
                List<Post> data = await _newsService.Get();
                Posts = new(data);
            }
			catch(Exception ex)
			{
				await HandleException(ex);
			}
			IsBusy = false;
        }

		private async Task OpenPostView(Post post)
		{
			await Navigation.NavigateTo(nameof(PostViewModel), post);
		}
    }
}

