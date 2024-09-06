using ChatStudents_Graf.Models;
using System.Windows;
using System.Windows.Controls;

namespace ChatStudents_Graf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public Users LoginUser = null;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPages(new Pages.Login());
        }
        public void OpenPages(Page page) =>
            frame.Navigate(page);
    }
}
