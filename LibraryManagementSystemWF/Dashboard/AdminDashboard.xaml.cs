using LibraryManagementSystem.dashboard.AdminControlForm;
using LibraryManagementSystem.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManagementSystem.dashboard
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {


        private Ctrldashboard dashboard = new Ctrldashboard();
        private Ctrlstatus status = new Ctrlstatus();
        private Ctrlauthor author = new Ctrlauthor();
        private Ctrlbooks books = new Ctrlbooks();
        private Ctrlloans loans = new Ctrlloans();
        private Ctrlmembers members = new Ctrlmembers();
        public AdminDashboard()
        {
            InitializeComponent();

            MainGrid.Children.Add(dashboard);
            MainGrid.Children.Add(status);
            MainGrid.Children.Add(author);
            MainGrid.Children.Add(books);
            MainGrid.Children.Add(loans);
            MainGrid.Children.Add(members);

            dashboard.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Collapsed;
            author.Visibility = Visibility.Collapsed;
            books.Visibility = Visibility.Collapsed;
            loans.Visibility = Visibility.Collapsed;    
            members.Visibility = Visibility.Collapsed;


            
        }


        


        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {

            dashboard.Visibility = Visibility.Visible;
            status.Visibility = Visibility.Collapsed;
            author.Visibility = Visibility.Collapsed;
            books.Visibility = Visibility.Collapsed;
            loans.Visibility = Visibility.Collapsed;
            members.Visibility = Visibility.Collapsed;

        }

        private void bntStatus_Click(object sender, RoutedEventArgs e)
        {

            dashboard.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Visible;
            author.Visibility = Visibility.Collapsed;
            books.Visibility = Visibility.Collapsed;
            loans.Visibility = Visibility.Collapsed;
            members.Visibility = Visibility.Collapsed;

        }

        private void btnAuthor_Click(object sender, RoutedEventArgs e)
        {

            dashboard.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Collapsed;
            author.Visibility = Visibility.Visible;
            books.Visibility = Visibility.Collapsed;
            loans.Visibility = Visibility.Collapsed;
            members.Visibility = Visibility.Collapsed;

        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {

            dashboard.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Collapsed;
            author.Visibility = Visibility.Collapsed;
            books.Visibility = Visibility.Visible;
            loans.Visibility = Visibility.Collapsed;
            members.Visibility = Visibility.Collapsed;

        }

        private void btnLoans_Click(object sender, RoutedEventArgs e)
        {

            dashboard.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Collapsed;
            author.Visibility = Visibility.Collapsed;
            books.Visibility = Visibility.Collapsed;
            loans.Visibility = Visibility.Visible;
            members.Visibility = Visibility.Collapsed;

        }

        private void btnMembers_Click(object sender, RoutedEventArgs e)
        {

            dashboard.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Collapsed;
            author.Visibility = Visibility.Collapsed;
            books.Visibility = Visibility.Collapsed;
            loans.Visibility = Visibility.Collapsed;
            members.Visibility = Visibility.Visible;

        }
    }
}
