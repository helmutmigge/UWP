using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismCRUD.Models;
using PrismCRUD.Repositories;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCRUD.ViewModels
{

    class AddPersonPageViewModel: ViewModelBase
    {
        private IPersonRepository personRepository;
        private INavigationService navigation;

        public AddPersonPageViewModel(INavigationService navigation, IPersonRepository personRepository) {
            this.personRepository = personRepository;
            this.navigation = navigation;
            buildCommands();        
        }

        private void buildCommands() {
            SaveCommand = new DelegateCommand(async () =>
            {
                await this.personRepository.SavePersonAsync(this.CurrentPerson);
                navigation.GoBack();
            });

            CancelCommand = new DelegateCommand(() =>
            {                
                navigation.GoBack();
            });
        }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        private Person currentPerson;

        public Person CurrentPerson {
            get {
                return this.currentPerson;
            }
            set
            {
                SetProperty(ref currentPerson, value);
            }
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            if (e.Parameter != null && e.Parameter is Person)
            {
                CurrentPerson = (Person) e.Parameter;
            }
            else {
                CurrentPerson = new Person();
            }       
        }

    }
}
