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

namespace чзхноваялаба
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();
            var currentAgent = ivanov_GlazkiEntities.GetContext().Agent.ToList();

            ServiceListView.ItemsSource = currentAgent;
            ComboType.SelectedIndex = 0;
            ComboSort.SelectedIndex = 0;
        }

        public void UpdateAgent()
        {
            var currentAgent = ivanov_GlazkiEntities.GetContext().Agent.ToList();
            if (ComboType.SelectedIndex == 0)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID >= 1 && p.AgentTypeID <= 6)).ToList();
            }
            if (ComboType.SelectedIndex == 1)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 1)).ToList();
            }
            if (ComboType.SelectedIndex == 2)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 2)).ToList();
            }
            if (ComboType.SelectedIndex == 3)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 3)).ToList();
            }
            if (ComboType.SelectedIndex == 4)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 4)).ToList();
            }
            if (ComboType.SelectedIndex == 5)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 5)).ToList();
            }
            if (ComboType.SelectedIndex == 6)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 6)).ToList();
            }



            if (ComboSort.SelectedIndex == 0)//все
            {
            }
            if (ComboSort.SelectedIndex == 1)//наименование(А до Я) 1
            {
                currentAgent = currentAgent.OrderBy(p => p.Priority).ToList();
            }
            if (ComboSort.SelectedIndex == 2)//наименование(Я до А) 2
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Priority).ToList();
            }
            if (ComboSort.SelectedIndex == 3)//размер скидки(по возрастанию) 3
            {
            }
            if (ComboSort.SelectedIndex == 4)//размер скидки(по убыванию) 4 
            {
            }
            if (ComboSort.SelectedIndex == 5)//приоритет агента(по возрастанию) 5
            {
                currentAgent = currentAgent.OrderBy(p => p.Priority).ToList();
            }
            if (ComboSort.SelectedIndex == 6) //приоритет агента(по убыванию) 6
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Priority).ToList();
            }                           
               
            currentAgent = currentAgent.Where(p =>
            p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())
            || p.Phone.Replace("+7", "8").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")
            .Contains(TBoxSearch.Text.Replace("+7", "8").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""))
            || p.Email.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();



            ServiceListView.ItemsSource = currentAgent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.GoBack();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
