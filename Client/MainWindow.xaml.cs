using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ObservableCollection<DataTransferObjectLibrary.Person> _persons = new ObservableCollection<DataTransferObjectLibrary.Person>();

        private ObservableCollection<DataTransferObjectLibrary.Person> Persons
        {
            get
            {
                return _persons;
            }
        }

        private void InsertData(DataTransferObjectLibrary.Person person)
        {
            using (ServiceReference.ServiceClient client = new ServiceReference.ServiceClient())
            {
                int result = client.InsertPerson(person);
            }
        }

        private void UpdateData(DataTransferObjectLibrary.Person person)
        {
            using (ServiceReference.ServiceClient client = new ServiceReference.ServiceClient())
            {
                int result = client.UpdatePerson(person);
            }
        }

        private void RemoveData(DataTransferObjectLibrary.Person person)
        {
            using (ServiceReference.ServiceClient client = new ServiceReference.ServiceClient())
            {
                int result = client.DeletePerson(person.Id);
            }
        }

        private void Refresh()
        {
            DataTransferObjectLibrary.ListOfPerson persons;
            using (ServiceReference.ServiceClient client = new ServiceReference.ServiceClient())
            {
                persons = client.GetAllPerson();
            }

            this.Persons.Clear();

            foreach (var item in persons.PersonList)
            {
                this.Persons.Add(item);
            }

            this.data.ItemsSource = this.Persons;
            this.data.DisplayMemberPath = "FirstName";
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.InsertData(new DataTransferObjectLibrary.Person()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                BirthDate = new DataTransferObjectLibrary.DateTime()
                {
                    Year = 1900,
                    Month = 10,
                    Day = 1
                }
            });

            this.Refresh();
        }
    }
}
