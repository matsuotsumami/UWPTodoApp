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
            UserList = model.UserList;

            var findId = UserList.Find(x => x.UserId == UserId);
            var findPass = UserList.Find(y => y.UserPassword == UserPassword);

            if (findId == null || findPass == null)
            {
                Debug.WriteLine(false);
                ErrorVisible = Visibility.Visible;
                ErrorText = "Id、またはPasswordが間違っています";
            }
            else if (findId == findPass)
            {
                ErrorVisible = Visibility.Collapsed;
                model.LoginUser = findId.UserId;
                Debug.WriteLine(true);
                NavigateService.GoTopView();
            }
            else
            {
                Debug.WriteLine(false);
                ErrorVisible = Visibility.Visible;
                ErrorText = "Id、またはPasswordが間違っています";
            }

            //var list = new List<string>();
            //list.AddRange(model.UserId);

            //if (list.Contains(UserId) == true)
            //{
            //    Debug.WriteLine(true);

            //    NavigateService.GoTopView();
            //}
            //else
            //{
            //    Debug.WriteLine(false);
            //}

        }
    }
}
