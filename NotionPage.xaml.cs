using MauiApp6.ViewModels;
namespace MauiApp6;

public partial class NotionPage : ContentPage
{

    public NotionViewModel ViewModel { get; private set; }
    public NotionPage(NotionViewModel vm)
    {
        InitializeComponent();
        ViewModel = vm;
        this.BindingContext = ViewModel;
    }
}