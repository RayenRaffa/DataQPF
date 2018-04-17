using System;
using System.Collections.Generic;
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

namespace DataQPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height = SystemParameters.VirtualScreenHeight;
            this.Width = SystemParameters.VirtualScreenWidth;
            this.Left = 0;
            this.Top = 0;
            SideMenu.Width = SystemParameters.VirtualScreenWidth / 6;
            LoadButton.Width = SideMenu.Width * 0.7;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dataFileSelectionDialog = new Microsoft.Win32.OpenFileDialog();

            dataFileSelectionDialog.DefaultExt = ".csv";
            dataFileSelectionDialog.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xls , *.xlsx)|*.xls;*.xlsx";

            Nullable<bool> selectedFile = dataFileSelectionDialog.ShowDialog();

            if (selectedFile == true)
            {
                string fileName = dataFileSelectionDialog.FileName;

                MessageBox.Show(fileName);
                CsvReader reader = new CsvReader(fileName);
                Data my_data = reader.read_file();
                my_data.data_summery(); 
            }
        }
    }
}
