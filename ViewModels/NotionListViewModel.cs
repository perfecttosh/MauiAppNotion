using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MauiApp6.ViewModels;
using MauiApp6.Models;
using MauiApp6;

public class NotionsListViewModel : INotifyPropertyChanged
{
    public ObservableCollection<NotionViewModel> Notions { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand CreateNotionCommand { protected set; get; }
    public ICommand DeleteNotionCommand { protected set; get; }
    public ICommand SaveNotionCommand { protected set; get; }
    public ICommand BackCommand { protected set; get; }
    NotionViewModel selectedNotion;

    public INavigation Navigation { get; set; }

    public NotionsListViewModel()
    {
        Notions = new ObservableCollection<NotionViewModel>();
        CreateNotionCommand = new Command(CreateNotion);
        DeleteNotionCommand = new Command(DeleteNotion);
        SaveNotionCommand = new Command(SaveNotion);
        BackCommand = new Command(Back);
    }

    public NotionViewModel SelectedNotion
    {
        get { return selectedNotion; }
        set
        {
            if (selectedNotion != value)
            {
                NotionViewModel tempNotion = value;
                selectedNotion = null;
                OnPropertyChanged("SelectedNotion");
                Navigation.PushAsync(new NotionPage(tempNotion));
            }
        }
    }

    protected void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    private void CreateNotion()
    {
        Navigation.PushAsync(new NotionPage(new NotionViewModel() { ListViewModel = this }));
    }

    private void Back()
    {
        Navigation.PopAsync();
    }

    private void SaveNotion(object notionObject)
    {
        NotionViewModel notion = notionObject as NotionViewModel;
        if (notion != null && notion.IsValid && !Notions.Contains(notion))
        {
            Notions.Add(notion);
        }
        Back();
    }

    private void DeleteNotion(object notionObject)
    {
        NotionViewModel notion = notionObject as NotionViewModel;
        if (notion != null)
        {
            Notions.Remove(notion);
        }
        Back();
    }
}