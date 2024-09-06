using System.Windows.Controls;
using ChatStudents_Graf.Classes.Common;
using ChatStudents_Graf.Models;

namespace ChatStudents_Graf.Pages.Items
{
    /// <summary>
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class Message : UserControl
    {
        public Message(Messages Messages, Users UserFrom)
        {
            InitializeComponent();
            imgUser.Source = BitmapFromArrayByte.LoadImage(UserFrom.Photo);
            FIO.Content = UserFrom.ToFIO();
            tbMessage.Text = Messages.Message;
        }
    }
}
