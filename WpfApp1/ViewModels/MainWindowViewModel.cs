using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using WpfApp1.Command;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel
    {
        public TextBox Name { get; set; }
        public TextBox Surname { get; set; }
        RelayCommand SaveCommand { get; set; }


        public MainWindowViewModel()
        {
            SaveCommand = new RelayCommand(obj =>
            {
                Surname.Text = Name.Text;
                Name.Text = "";
            });
        }

    }
}
