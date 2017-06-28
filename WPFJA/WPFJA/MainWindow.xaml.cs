using System;
using System.Net;
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


namespace WPFJA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatientInfo patient = new PatientInfo();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            resetAll();
        }
        
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            gatherFormData();
            sendToDB();
        }

        public void resetAll()
        {
            NameText.Text = String.Empty;
            AgeText.Text = String.Empty;
            StatusBox.SelectedIndex = 0;
            string checkBoxName = "CB";
            for (int i = 0; i <= 7; i++)
            {
                checkBoxName = checkBoxName + i.ToString();
                var checkBox = (CheckBox)this.FindName(checkBoxName);
                checkBox.IsChecked = false;
                checkBoxName = "CB";
            }
        }

        public void gatherFormData() {
            patient.FullName = NameText.Text.ToString();
            patient.Age = AgeText.Text.ToString();
            patient.Status = StatusBox.Text;
            patient.Symptons = formCheckBoxString();
        }

        public void sendToDB() {
            string URI = "http://localhost/sendPatient.php";
            string parameters = "p_name=" + patient.FullName + "&p_age=" + patient.Age + "&p_status=" + patient.Status + "&p_symptons=" + patient.Symptons;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, parameters);
                MessageBox.Show("Form Sent");
                resetAll();
            }
        }

        public string formCheckBoxString() {
            string checkBoxName = "CB";
            string output = "";
            for (int i = 0; i <= 7; i++)
            {
                checkBoxName = checkBoxName + i.ToString();
                var checkBox = (CheckBox)this.FindName(checkBoxName);

                if (checkBox.IsChecked == true) {
                    output = output + checkBox.Content.ToString() + ",";
                }
                checkBoxName = "CB";
            }
            return output;
        }
    }
}
