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

namespace DrinkChoice
{
    /// <summary>
    /// Interaction logic for RestaurantControl.xaml
    /// </summary>
    public partial class RestaurantControl : UserControl
    {
        public RestaurantControl()
        {
            InitializeComponent();
        }

        public void LoadChoices()
        {
            //Create and add checkboxes for all SodaChoices
            if (DataContext is Restaurant r)
            {
                //We want a checkbox for everything in r.PossibleSodas

                StackPanel stack = new StackPanel();

                foreach (SodaChoice choice in r.PossibleSodas)
                { 
                    CheckBox box = new CheckBox();
                    box.DataContext = choice;
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath(nameof(choice.Chosen));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);

                    TextBlock block = new TextBlock();
                    block.Text = choice.ToString();
                    box.Content = block;

                    stack.Children.Add(box);        //Adds check box to a stack panel
                }

                //Add stack to my DockPanel
                restDock.Children.Add(stack);
            }
        }
    }
}
