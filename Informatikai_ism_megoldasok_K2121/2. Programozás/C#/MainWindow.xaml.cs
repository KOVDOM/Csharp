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

namespace SuperBowlGUI
{
    // A konzols részből áthozva és módosítva:
    class Átváltó
    {
        public static string RómaiToArab(string római)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>
            {
               {"I", "1"},
               {"II", "2"},
               {"III", "3"},
               {"IV", "4"},
               {"V", "5"},
               {"VI", "6"},
               {"VII", "7"},
               {"VIII", "8"},
               {"IX", "9"},
               {"X", "10"}
            };
            return helper.ContainsKey(római.ToUpper()) ? helper[római.ToUpper()] : "Hiba!";
        }
        public static string ArabToRómai(string arab)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>
            {
               {"1", "I"},
               {"2", "II"},
               {"3", "III"},
               {"4", "IV"},
               {"5", "V"},
               {"6", "VI"},
               {"7", "VII"},
               {"8", "VIII"},
               {"9", "IX"},
               {"10", "X"}
            };
            return helper.ContainsKey(arab) ? helper[arab] : "Hiba!";
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIrány_Click(object sender, RoutedEventArgs e)
        {
            InputRómai.Text = "";
            InputArab.Text = "";
            if (InputRómai.IsEnabled)
            {
                InputRómai.IsEnabled = false;
                InputArab.IsEnabled = true;
                BtnIrány.Content = "<---";
            }
            else
            {
                InputRómai.IsEnabled = true;
                InputArab.IsEnabled = false;
                BtnIrány.Content = "--->";
            }
        }

        private void BtnÁtvált_Click(object sender, RoutedEventArgs e)
        {
            if (InputRómai.IsEnabled)
            {
                InputArab.Text = Átváltó.RómaiToArab(InputRómai.Text);
            }
            else
            {
                InputRómai.Text = Átváltó.ArabToRómai(InputArab.Text);
            }
        }
    }
}
