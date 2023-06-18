using System;
namespace PostsApp.ViewModels
{
	public partial class PostViewModel: ViewModel
	{
		public PostViewModel()
		{
		}

        [ObservableProperty]
        private Post post;

        public override async Task OnParameterSet()
        {
            await base.OnParameterSet();

            Post = NavigationParameter as Post;
        }
    }
}

