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
using OrderingSystem.Domain;
using OrderingSystem.Logic;
using OrderingSystem.Logic.Interfaces;
using OrderingSystem.Logic.SqlLogic;

namespace OrderingSystem.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ILocationLogic locationLogic = new SqlLocationLogic();
            ICategoryLogic categoryLogic = new SqlCategoryLogic();
            IDrinkLogic drinkLogic = new SqlDrinkLogic();
            ICustomerLogic customerLogic = new SqlCustomerLogic();
            ITableLogic tableLogic = new SqlTableLogic();

            // Get all Locations
            var locations = locationLogic.GetLocations();

            int counter = 0;
            foreach (var location in locations)
            {
                // Create tab item
                var tabItem = new TabItem();
                tabItem.Header = location.Name;
                tabItem.FontSize = 20;
                tabItem.Height = 40;
                tabItem.Width = 150;

                Tabs.Items.Insert(counter, tabItem);

                var grid = new Grid();
                
                tabItem.Content = grid;

                var tables = tableLogic.GetTablesByLocation(location.Id);
                
                foreach (var table in tables)
                {

                    var button = new Button()
                    {
                        Content = table.Label,
                        FontSize = 20,
                        Height = table.WpfInfo.Height,
                        Width = table.WpfInfo.Width,
                        Padding = new Thickness(table.WpfInfo.PosX, -table.WpfInfo.PosY, 0, 0)
                    };

                    button.Click += table_Clicked;
  
                    grid.Children.Add(button);
                }
            }
        }

        private void table_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}