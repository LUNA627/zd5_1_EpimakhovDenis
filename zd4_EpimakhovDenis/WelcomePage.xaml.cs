using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace zd4_EpimakhovDenis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        async void OnSignInClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                DisplayAlert("Ошибка", "Введите имя!", "OK");
                return;
            }


            if (string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Ошибка", "Введите пароль!", "OK");
                return;
            }

            if (!rem.IsChecked)
            {
                DisplayAlert("Ошибка", "Нажмите <запомнить меня>", "ОК");
                return;
            }

            try
            {
                CheckedValidUsername(username);
                CheckedValidUsername(password);

            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
                return;
            }
            NavigateToTabbedPage(username);



            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;



        }


        private async Task NavigateToTabbedPage(string username)
        {
            var tabbedPage = new MainPage(username);
            await Navigation.PushAsync(tabbedPage);
        }


        public static void CheckedValidUsername(string username)
        {
            if (username.Length < 5)
            {
                throw new Exception("Минимальная длина имени 5 символов");

            }
            if (username.Length > 12)
            {
                throw new Exception("Максимальная длина имени 12 символов");
            }

            foreach (char c in username)
            {
                if (char.IsLetter(c) || c == ' ')
                {
                    continue;
                }
                else
                {
                    throw new Exception("Имя пользователя содержит только буквы и пробелы");
                }
            }
        }
        public static void CheckedValidPassword(string password)
        {
            if (password.Length < 8)
            {
                throw new Exception("Пароль содержит минимум 8 символов");
            }
            if (password.Length > 20)
            {
                throw new Exception("Пароль содержит максимум 20 символов");
            }
        }
    }
}