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

namespace LoginFunctionality
{
    /// <summary>
    /// Interaction logic for PersonData.xaml
    /// </summary>
    public partial class PersonData : UserControl
    {
        public List<Stats> Stats = new List<Stats>
        {
            new Stats{Level = 10, Age = 20, Name ="Anna"}
        };

        public PersonData()
        {
            InitializeComponent();
            ListStats.ItemsSource = Stats;
        }

        private void ListStats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
