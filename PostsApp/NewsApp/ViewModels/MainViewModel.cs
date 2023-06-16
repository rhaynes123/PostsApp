using CommunityToolkit.Mvvm.ComponentModel;

namespace PostsApp.ViewModels
{
	public partial class MainViewModel: ViewModel
	{
		private readonly IPostsService _newsService;
		public MainViewModel(IPostsService newsService)
		{
			_newsService = newsService;					
		}

		[ObservableProperty]
		private ObservableCollection<Post> items = new();
        public override async Task Initialize()
        {
            await base.Initialize();

			try
			{
				IsBusy = true;
                List<Post> data = await _newsService.Get();
                Items = new(data);
            }
			catch(Exception ex)
			{
				// TODO handle ex
			}
			IsBusy = false;
        }

    }
}

