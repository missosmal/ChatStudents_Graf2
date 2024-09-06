using System.Windows.Controls;
using ChatStudents_Graf.Classes.Common;
using ChatStudents_Graf.Models;


namespace ChatStudents_Graf.Pages.Items
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        Users user;
        Main main;
        public User(Users user, Main main)
        {
            InitializeComponent();
            this.user = user;
            this.main = main;
            imgUser.Source = BitmapFromArrayByte.LoadImage(user.Photo);
            FIO.Content = user.ToFIO();
        }
        private void SelectChat(object sender, System.Windows.Input.MouseButtonEventArgs e) =>
            main.SelectUser(user);
    }
}
