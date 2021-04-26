using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace UWPTodoApp.Services
{
    public class NavigateService
    {        
        private void navigate(System.Type page, Object param)
        {
            App.navigateFrame.Navigate(page, param, new DrillInNavigationTransitionInfo());
        }

        public void GoBack()
        {
            App.navigateFrame.GoBack();
        }

        public void GoSignIn()
        {
            this.navigate(typeof(UWPTodoApp.Views.SigninPageView), null);
        }

        public void GoTopView()
        {
            this.navigate(typeof(UWPTodoApp.Views.TopView), null);
        }

        public void GoTodoView()
        {
            this.navigate(typeof(UWPTodoApp.Views.TodoView), null);
        }
    }
}
