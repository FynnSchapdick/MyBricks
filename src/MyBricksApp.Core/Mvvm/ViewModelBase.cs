using Prism.Mvvm;

namespace MyBricksApp.Core.Mvvm
{
    public class ViewModelBase : BindableBase
    {
        private string _title = "defaultTile";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value, nameof(Title));
        }
    }
}