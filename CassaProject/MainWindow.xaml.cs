using CassaProject.ViewModel;
using CassaProject.Model;
using System.Windows;

namespace CassaProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }
        public MainWindow()
        {
            ViewModel = new MainViewModel();
            InitializeComponent();
        }

        private void ButtonRecordInFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ViewModel.Sum))
            {
                MessageBox.Show("Не введена сумма, невозможно сохранить данные в файл", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ViewModel.CountOfBag) && ViewModel.TypeOfCashOper == CashOperation.Инкассация)
            {
                MessageBox.Show("Не введен номер сумки, невозможно сохранить данные в файл", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ViewModel.ReasonOfOperText) && ViewModel.TypeOfCashOper == CashOperation.ПеремещениеМеждуКассами)
            {
                MessageBox.Show("Не указана причина операции, невозможно сохранить данные в файл", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ViewModel.WriteInFile();
        }
    }
}
