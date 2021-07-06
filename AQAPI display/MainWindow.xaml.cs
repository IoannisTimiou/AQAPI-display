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

namespace AQAPI_display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //defaults for paremeters country, city and date
        private string country = "GB";
        private string city = "Manchester";
        private DateTime date = new DateTime(2021, 7, 4);

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        //sets the selected date
        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = (DateTime) datePicker.SelectedDate;
        }

        //sets the selected country and/or city
        private void SetParameters_Click(object sender, RoutedEventArgs e)
        {
            if (CountryCode.Text.Length == 2)
            {
                country = CountryCode.Text;
            }
            if (CityName.Text != null)
            {
                city = (CityName.Text);
            }
        }

        //triggers upon clicking the button "Latest air quality for city", returns the air quality measured for that city at midnight of given date by calling on the AQMeasurement method of AQDataRetrieve
        private async void Latest_Click(object sender, RoutedEventArgs e)
        {
            AQlatestinfo.Text = "";
            var aqinfo = await AQDataRetrieve.AQMeasurement(country, city, date);
            AQlatestinfo.Text = aqinfo.city + ", " + aqinfo.country + ", " + date.ToString("MM/dd/yyyy") + ": " + aqinfo.value;
        }

        //triggers upon clicking the button "Average air quality results for country", returns the average air quality measured for that country for the given date by calling on the AverageAQ method of AQDataRetrieve
        private async void Average_Click(object sender, RoutedEventArgs e)
        {
            AQaverage.Text = "";
            var averageinfo = await AQDataRetrieve.AverageAQ(country, date);
            AQaverage.Text = averageinfo.name + ", " + date.ToString("MM/dd/yyyy") + ": " + averageinfo.average;
        }
    }
}
