
namespace ExpandableListView.Views
{
    using ExpandableListView.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpandableList : ContentPage
    {
        public ExpandableList()
        {
            this.InitializeComponent();
            this.BindingContext = new ExpandableListViewModel();
        }
    }
}