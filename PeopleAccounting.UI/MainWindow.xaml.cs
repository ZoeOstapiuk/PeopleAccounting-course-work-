using Microsoft.Win32;
using PeopleAccounting.UI.PersonDisplayHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PeopleAccounting.UI
{
    public partial class MainWindow : Window
    {
        private IPeopleRepository repo;

        public MainWindow()
        {
            InitializeComponent();
            setUpInterface();

            repo = new PeopleRepository();
            this.dataGridPeople.ItemsSource = repo;
        }

        private void setUpInterface()
        {
            this.choosePanel.IsChecked = true;
            this.toolBarVisibility.IsChecked = true;
            (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;
        }

        private Person getPersonFromInfoEditor()
        {
            Person result = null;
            try
            {
                PhoneNumber number = new PhoneNumber(this.number.Text);
                Address address = new Address
                {
                    Country = this.country.Text,
                    Region = this.region.Text,
                    Locality = this.locality.Text,
                    Street = this.street.Text,
                    BuildingNumber = this.buildNum.Value.Value,
                    ApartamentNumber = this.apartNum.Value.Value
                };

                result = new Person
                {
                    ID = this.idNum.Value.Value,
                    LastName = this.lastName.Text,
                    FirstName = this.firstName.Text,
                    Number = number,
                    Address = address
                };
            }
            catch (InvalidNumberException)
            {
                MessageBox.Show("Будь ласка, введіть правильні дані для телефона", this.Title);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Будь ласка, заповність усі поля", this.Title);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Будь ласка, заповнюйте поля номерів будинку/квартири/ІД, використовуючи числа", this.Title);
            }

            return result;
        }

        private Address getAddress()
        {
            Address result = null;
            try
            {
                result = new Address
                {
                    Country = this.findCountry.Text,
                    Region = this.findRegion.Text,
                    Locality = this.findLocality.Text,
                    Street = this.findStreet.Text,
                    BuildingNumber = this.findApart.Value.Value,
                    ApartamentNumber = this.findApart.Value.Value
                };
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Будь ласка, заповність усі поля адреси", this.Title);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Будь ласка, введіть номер будинку і квартири правильно", this.Title);
            }

            return result;
        }

        private PhoneNumber getNumber()
        {
            PhoneNumber result = null;
            if(!PhoneNumber.IsValid(this.findPhoneNumber.Text))
            {
                MessageBox.Show("Будь ласка, введіть коректний номер телефону", this.Title);
            }
            else
            {
                result = new PhoneNumber(this.findPhoneNumber.Text);
            }

            return result;
        }

        #region Window Related Events
        private void dataGridPeople_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var attribute = desc.Attributes[typeof(ColumnNameAttribute)] as ColumnNameAttribute;
            if (attribute != null)
            {
                e.Column.Header = attribute.ColumnName;
            }
        }

        private void choosePanel_Checked(object sender, RoutedEventArgs e)
        {
            this.mainGrid.ColumnDefinitions[0].Width = new GridLength(0.5, GridUnitType.Star);
            this.mainGrid.ColumnDefinitions[1].Width = new GridLength(1.3, GridUnitType.Star);
        }

        private void choosePanel_Unchecked(object sender, RoutedEventArgs e)
        {
            this.mainGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
            this.mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
        }

        private void toolBarVisibility_Checked(object sender, RoutedEventArgs e)
        {
            this.mainToolBarTray.Visibility = Visibility.Visible;
        }

        private void toolBarVisibility_Unchecked(object sender, RoutedEventArgs e)
        {
            this.mainToolBarTray.Visibility = Visibility.Collapsed;
        }

        private void dataGridPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as DataGrid).SelectedItem;
            if (item != null && this.tabSystem.SelectedIndex == 0)
            {
                Person selectedPerson = item as Person;

                this.idNum.Value = selectedPerson.ID;
                this.lastName.Text = selectedPerson.LastName;
                this.firstName.Text = selectedPerson.FirstName;
                this.number.Text = selectedPerson.Number.ToString();
                this.country.Text = selectedPerson.Address.Country;
                this.region.Text = selectedPerson.Address.Region;
                this.locality.Text = selectedPerson.Address.Locality;
                this.street.Text = selectedPerson.Address.Street;
                this.buildNum.Value = selectedPerson.Address.BuildingNumber;
                this.apartNum.Value = selectedPerson.Address.ApartamentNumber;
            }
        }
        #endregion

        #region Main Functions
        private void btnfindAddressByLastname_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGridPeople.ItemsSource != null && !String.IsNullOrWhiteSpace(this.findLastname.Text))
            {
                IEnumerable<Person> result = repo.FindAddressesByLastname(this.findLastname.Text);
                if (result.Count() == 0)
                {
                    MessageBox.Show("На жаль, не було знайдено результатів", this.Title);
                    return;
                }

                (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Visible;
                this.tabSystem.SelectedIndex = 1;

                this.dataGridResults.ItemsSource = result.Select(p => p.Address);
                this.dataGridResults.Items.Refresh();
            }
        }

        private void btnfindNamesAndAddressByPhone_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGridPeople.ItemsSource != null)
            {
                PhoneNumber number = getNumber();
                if (number == null)
                {
                    return;
                }

                IEnumerable<Person> result = repo.FindPeopleByPhoneNumber(number);
                if (result.Count() == 0)
                {
                    MessageBox.Show("На жаль, не було знайдено результатів", this.Title);
                    return;
                }

                (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Visible;
                this.tabSystem.SelectedIndex = 1;

                this.dataGridResults.ItemsSource = result.Select(p => new NameAndAddress
                {
                    FirstName = p.FirstName,
                    Address = p.Address
                });
                this.dataGridResults.Items.Refresh();
            }
        }

        private void btnfindPeopleByAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = getAddress();
            if (this.dataGridPeople.ItemsSource != null && address != null)
            {
                IEnumerable<Person> result = repo.FindPeopleByAddress(address);
                if (result.Count() == 0)
                {
                    MessageBox.Show("На жаль, не було знайдено результатів", this.Title);
                    return;
                }

                (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Visible;
                this.tabSystem.SelectedIndex = 1;
      
                this.dataGridResults.ItemsSource = result;
                this.dataGridResults.Items.Refresh();
            }
        }

        private void btnfindSameNameAddressByPhone_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGridPeople.ItemsSource != null)
            {
                PhoneNumber number = getNumber();
                if (number == null)
                {
                    return;
                }

                IEnumerable<Person> result = repo.FindSameNamesStreetsByPhoneNumber(number);
                if (result.Count() == 0)
                {
                    MessageBox.Show("На жаль, не було знайдено результатів", this.Title);
                    return;
                }

                (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Visible;
                this.tabSystem.SelectedIndex = 1;

                this.dataGridResults.ItemsSource = result.Select(p => new NameAndStreet
                {
                    FirstName = p.FirstName,
                    Street = p.Address.Street
                });
                this.dataGridResults.Items.Refresh();
            }
        }

        private void btnfindFullNameByAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = getAddress();
            if (this.dataGridPeople.ItemsSource != null && address != null)
            {
                IEnumerable<Person> result = repo.FindPeopleByAddress(address);
                if (result.Count() == 0)
                {
                    MessageBox.Show("На жаль, не було знайдено результатів", this.Title);
                    return;
                }

                (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Visible;
                this.tabSystem.SelectedIndex = 1;

                this.dataGridResults.ItemsSource = result.Select(p => new FullName
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName
                });
                this.dataGridResults.Items.Refresh();
            }
        }
        #endregion

        #region Menu Buttons
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.fileName.Text = "Немає відкритих файлів";

            repo.Clear();
            this.dataGridPeople.Items.Refresh();
            (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.DefaultExt = "txt";
            openDlg.Filter = "Txt файли| *.txt";

            if (openDlg.ShowDialog() == true)
            {
                PeopleRepositoryFileHandler reader = new PeopleRepositoryFileHandler();
                try
                {
                    repo = reader.ReadFromTextFile(openDlg.FileName);
                    this.dataGridPeople.ItemsSource = repo;

                    this.fileName.Text = openDlg.FileName;
                    (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;

                    if (reader.Report.Count != 0)
                    {
                        StringBuilder errors = new StringBuilder();
                        foreach (var error in reader.Report)
                        {
                            errors.AppendLine(String.Format("№{0} - {1}", error.Key, error.Value));
                        }

                        MessageBox.Show(errors.ToString(), "Некоректні записи");
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Оберіть правильний .txt файл", this.Title);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!this.fileName.Text.EndsWith(".txt"))
            {
                return;
            }

            try
            {
                PeopleRepositoryFileHandler writer = new PeopleRepositoryFileHandler();
                writer.WriteToFile(this.fileName.Text, repo);
            }
            catch
            {
                MessageBox.Show("Сталася помилка. Перевірте, чи редагований файл створений", this.Title);
            }
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.DefaultExt = "txt";
            saveDlg.Filter = "Txt файли| *.txt";

            if (saveDlg.ShowDialog() == true)
            {
                PeopleRepositoryFileHandler writer = new PeopleRepositoryFileHandler();
                try
                {
                    writer.WriteToFile(saveDlg.FileName, repo);
                    this.fileName.Text = saveDlg.FileName;
                }
                catch 
                {
                    MessageBox.Show("Оберіть правильний .txt файл", this.Title);
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            int index = this.dataGridPeople.SelectedIndex;
            if (-1 < index && index < repo.Count)
            {
                Person person = getPersonFromInfoEditor();
                if (person != null)
                {
                    try
                    {
                        repo.Update(index, person);
                        this.dataGridPeople.Items.Refresh();

                        (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(String.Format("Людина з таким ІД вже існує", ex.ParamName), this.Title);
                    }
                }
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            Person person = getPersonFromInfoEditor();
            if (person != null)
            {
                try
                {
                    repo.Add(person);
                    this.dataGridPeople.Items.Refresh();

                    (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(String.Format("Людина з таким ІД вже існує", ex.ParamName), this.Title);
                }
            }
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = this.dataGridPeople.SelectedItem as Person;
            if (selectedPerson != null)
            {
                repo.Delete(selectedPerson);
            }

            this.dataGridPeople.Items.Refresh();
            (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            repo.Clear();

            this.dataGridPeople.Items.Refresh();
            (this.tabSystem.Items[1] as TabItem).Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
