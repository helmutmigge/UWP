using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismCRUD.Models;
using PrismCRUD.Repositories;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Prism.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using PrismCRUD.Events;

namespace PrismCRUD.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private IEventAggregator eventAggregator;
        private IPersonRepository personRepository;

        private Person selectPerson;
        public Person SelectPerson {
            get {
                return this.selectPerson;
            }
            set
            {
                SetProperty(ref selectPerson, value);
                viewPersonPage(value);
            }
        }


        private string searchQuery;

        public string SearchQuery {
            get
            {
                return this.searchQuery;
            }
            set
            {
                SetProperty(ref searchQuery, value);
                Search(value);
            }
        }
         

        private async void Search(string query) {
            Data = new ObservableCollection<Person>(await personRepository.SearchPersonAsync(query));
        }

        public MainPageViewModel(INavigationService navigation, IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            this.personRepository = personRepository;
            this.navigation = navigation;
            this.eventAggregator = eventAggregator;
            BuildCommands();
        }

        private void BuildCommands() {
            AddCommand = new DelegateCommand(addPersonPage);
        }


        private void viewPersonPage(Person person)
        {
            this.navigation.Navigate(PageTokens.AddPerson.ToString(), person);
        }

        private void addPersonPage() {
            this.navigation.Navigate(PageTokens.AddPerson.ToString(), null);
        }

        public DelegateCommand AddCommand{ get; private set; }

        private ObservableCollection<Person> data;

        public ObservableCollection<Person> Data {
            get {
                return data;
            }
            set {
                SetProperty(ref data, value);
            }
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            Data = new ObservableCollection<Person>(await personRepository.GetPersonAsync());
            this.eventAggregator.GetEvent<AddPersonEvent>().Subscribe(autoADdPerson,ThreadOption.UIThread);
        }
        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
            this.eventAggregator.GetEvent<AddPersonEvent>().Unsubscribe(autoADdPerson);
        }

        private void autoADdPerson(Person person) {
            this.Data.Insert(0,person);

        }
    }
}
