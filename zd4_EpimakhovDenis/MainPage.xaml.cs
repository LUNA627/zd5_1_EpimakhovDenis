using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace zd4_EpimakhovDenis
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(string username)
        {
            InitializeComponent();
            BarBackgroundColor = Color.MidnightBlue;
            Title = $"Добро пожаловать, {username}!";
            this.Resources.Add(StyleSheet.FromResource("styles.css", typeof(MainPage).GetTypeInfo().Assembly));
        }
    }
}   
