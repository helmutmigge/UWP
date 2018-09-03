using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using PrismCRUD.Services;

namespace PrismCRUD.ViewModels
{
    public class AutoCreatePersonViewModel : ViewModelBase
    {
        private IAutoCreatePersonService service;

        public AutoCreatePersonViewModel(IAutoCreatePersonService service)
        {
            this.service = service;
            buildCommands();
        }

        private void buildCommands() {

            StartCommand = new DelegateCommand(async () => {
                this.service.startAsync();
                CancelCommand.RaiseCanExecuteChanged();
                StartCommand.RaiseCanExecuteChanged();
            }, () => !this.service.IsStarted());

            CancelCommand = new DelegateCommand(async () => {
                this.service.cancelAsync();
                CancelCommand.RaiseCanExecuteChanged();
                StartCommand.RaiseCanExecuteChanged();
            }, () => this.service.IsStarted());

        }

        public DelegateCommand StartCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }
    }
}
