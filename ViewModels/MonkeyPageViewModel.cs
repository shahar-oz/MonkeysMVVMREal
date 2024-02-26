using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MonkeysMVVM.ViewModels
{
    public class MonkeyPageViewModel:ViewModel
    {
        private MonkeysService monkeysService;
       
       public Monkey SelectedMonkey { get ; set; }
        public ICommand NavigateMonkeysView { get; private set; }
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public ICommand LoadMonkeysCommand { get; private set; }
        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public MonkeyPageViewModel(MonkeysService mservice)
        {
            monkeysService = mservice;
            Monkeys = new ObservableCollection<Monkey>();
            NavigateMonkeysView = new Command(async () => await Navigate());
            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
            
        }

        private async Task Navigate()
        {
            
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Monkey", SelectedMonkey);
            await AppShell.Current.GoToAsync("ShowMonkey", data);
        }
        private async Task LoadMonkeys()
        {
            IsRefreshing = true;
            MonkeysService monkeys = new MonkeysService();
            var list = monkeys.GetMonkey();
            for(int i =0; i < list.Count; i++)
            {
                Monkeys.Add(list[i]);
            }
            IsRefreshing = false;
           
        }
    }
}
