using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeBudgetManager.Common.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region properties
        public string WindowTitle { get; set; } = "Test title";
       // public string Summary { get; set; }
       // public string AddFile { get; set; }
       // public string GroupManagement { get; set; }
       //// public GroupPresenter Revenue { get; set; }
       // public List<string> DateList { get; set; }
       //// public ObservableCollection<TransactionInformations> MainList { get; set; }
       // public double MonthRevenue { get; set; }
       // public double MonthExpences { get; set; }

       // public RelayCommand AddFileCmd { get; set; }
       // public RelayCommand OpenGroupManagerCommand { get; set; }
       // public RelayCommand CloseCmd { get; }

        #endregion

        public MainWindowViewModel()
        {

        }


    }
}