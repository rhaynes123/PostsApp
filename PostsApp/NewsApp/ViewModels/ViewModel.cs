using System;
namespace PostsApp.ViewModels
{
	public abstract class ViewModel: TinyViewModel
	{
		public ViewModel()
		{
		}

		protected Task HandleException(Exception exception)
		{
			return Task.CompletedTask;
		}
	}
}

