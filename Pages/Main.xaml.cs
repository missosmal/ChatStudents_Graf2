using System;
using System.Collections.Generic;
using System.Text;
using ChatStudents_Graf.Classes;
using ChatStudents_Graf.Classes.Common;
using ChatStudents_Graf.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChatStudents_Graf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Users SelectedUser = null;
        public static UsersContext usersContext = new UsersContext();
        public MessagesContext messagesContext = new MessagesContext();
        public DispatcherTimer Timer = new DispatcherTimer() { Interval = new System.TimeSpan(0, 0, 3) };
        public Main()
        {
            InitializeComponent();
            LoadUsers();
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }
        public void LoadUsers()
        {
            ParentUsers.Children.Clear();
            foreach (Users user in usersContext.Users)
            {
                if (user.Id != MainWindow.Instance.LoginUser.Id)
                    ParentUsers.Children.Add(new Pages.Items.User(user, this));
            }
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            LoadUsers();
            if (SelectedUser != null)
                SelectUser(SelectedUser);
            usersContext = new UsersContext();
        }
        public void SelectUser(Users User)
        {
            SelectedUser = User;
            Chat.Visibility = Visibility.Visible;
            imgUser.Source = BitmapFromArrayByte.LoadImage(User.Photo);
            FIO.Content = User.ToFIO();
            ParentMessages.Children.Clear();
            foreach (Messages Message in messagesContext.Messages.Where(x =>
            (x.UserFrom == User.Id && x.UserTo == MainWindow.Instance.LoginUser.Id) ||
            (x.UserFrom == MainWindow.Instance.LoginUser.Id && x.UserTo == User.Id)).OrderBy(x => x.Id))
            {
                ParentMessages.Children.Add(new Pages.Items.Message(Message, usersContext.Users.Where(x => x.Id == Message.UserFrom).First()));
            }
        }
        private void Send(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Messages message = new Messages(MainWindow.Instance.LoginUser.Id, SelectedUser.Id, Message.Text);
                messagesContext.Messages.Add(message);
                messagesContext.SaveChanges();
                ParentMessages.Children.Add(new Pages.Items.Message(message, MainWindow.Instance.LoginUser));
                Message.Text = "";
                LoadUsers();
            }
        }
    }
}
