using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPTodoApp.Services
{
    public class NavigateService
    {        
        private void navigate(System.Type page, Object param)
        {
            App.navigateFrame.Navigate(page, param);
        }

        public void GoBack()
        {
            App.navigateFrame.GoBack();
        }

        //public void GoSignIn()
        //{
        //    this.navigate(typeof(UWPTodoApp.SignIn.SignInView), null);
        //}
    }
}
