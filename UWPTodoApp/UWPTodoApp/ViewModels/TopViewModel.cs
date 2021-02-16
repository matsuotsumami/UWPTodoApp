using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTodoApp.Helper;
using UWPTodoApp.Services;
using UWPTodoApp.Models;

namespace UWPTodoApp.ViewModels
{
    public class TopViewModel : Observable
    {
        private Models.UserModel userModel = DataModelService.Instance().UserModel;

        public void Initialize()
        {
            LoginUser = userModel.LoginUser;

            WelcomeMessage = "ようこそ " + LoginUser + " さん！";
        }

        private string _loginUser;
        public string LoginUser
        {
            get { return _loginUser; }
            set { Set(ref _loginUser, value); }
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { Set(ref _welcomeMessage, value); }
        }

        public void GoTodoButton_Click()
        {
            NavigateService.GoTodoView();
        }

        public void SignOutButton_Click()
        {
            NavigateService.GoSignIn();
        }
    }
}
