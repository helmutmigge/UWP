using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExampleCRUD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public PersonService PersonService { get; set; }
     
        public int Index { get; set; }

        public Person Person { get; set; }

        public ObservableCollection<Person> DataLst
        {
            get
            {
                return PersonService.GetAllPersons();
            }
            set
            {

            }
        }

        public MainPage()
        {
            PersonService = new PersonService();
            Person = new Person("Helmut", 35);
            Index = -1;
            this.InitializeComponent();
        }


        private void AddClick(object sender, RoutedEventArgs e)
        {
            PersonService.addPerson(Person);
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {            
            PersonService.removeIndex(Index);
        }
    }
}
