using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTodoApp.Helper;
using UWPTodoApp.Services;
using UWPTodoApp.Models;
using System.Diagnostics;
using Windows.UI.Xaml;

namespace UWPTodoApp.ViewModels
{
    public class SigninPageViewModel : Observable
    {
        private Models.UserModel model = DataModelService.Instance().UserModel;



        public void Initialize()
        {
            ErrorVisible = Visibility.Collapsed;
        }

        private Visibility _errorVisible;
        public Visibility ErrorVisible
        {
            get { return _errorVisible; }
            set { Set(ref _errorVisible, value); }
        }

        private string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            set { Set(ref _errorText, value); }
        }

        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { Set(ref _userId, value); }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set { Set(ref _userPassword, value); }
        }

        public List<Models.User> UserList { get; set; } = new List<Models.User>();

        public void SignInButton_Click()
        {
            var user = model.login(UserId, UserPassword);

            if (user == null)
            {
                Debug.WriteLine(false);
                ErrorVisible = Visibility.Visible;
                ErrorText = "Id、またはPasswordが間違っています";
                return;
            }
            ErrorVisible = Visibility.Collapsed;
            
            model.LoginUser = user;
            Debug.WriteLine(true);
            NavigateService.GoTopView();
        }
    }
}
