using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
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

namespace FileUploader
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Upload(string file)
        {
            //var uri = "http://api.terminal.dff.spb.ru/admin/uploadNomenclature ";
            //var uri = "http://localhost:13830/form.aspx";
            var uri = "http://api.dff.puzakov.me/admin/uploadNomenclature";
            //var uri = "http://puzakov.me";

            using (var client = new WebClient())
            {
                var data = new NameValueCollection();
                data["username"] = "myUser";
                data["password"] = "myPassword";

                var b = client.UploadFile(uri, file);
                //var b = client.UploadValues(uri, "POST", data);
                var a = Encoding.UTF8.GetString(b);
               
                MessageBox.Show(a);
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.FileName != "")
                Upload(dialog.FileName);

            Close();
        }
    }
}
