using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MauiApp6.Models;
namespace MauiApp6.ViewModels
{
    

    public class NotionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        NotionsListViewModel lvm;
        public NotionModel Notion { get; private set; }

        public NotionViewModel()
        {
            Notion = new NotionModel();
        }

        public NotionsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Title
        {
            get { return Notion.Title; }
            set
            {
                if (Notion.Title != value)
                {
                    Notion.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Description
        {
            get { return Notion.Description; }
            set
            {
                if (Notion.Description != value)
                {
                    Notion.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Title.Trim())) ||
                        (!string.IsNullOrEmpty(Description.Trim())));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}
