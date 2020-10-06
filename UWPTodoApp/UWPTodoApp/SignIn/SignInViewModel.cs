using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTodoApp.Helper;
using UWPTodoApp.Services;
using UWPTodoApp.Models;

namespace UWPTodoApp.SignIn
{
    public class SignInViewModel : Observable
    {
        public UserModel model = DataModelService.Instance().UserModel;

        public String TestUser;
        public void Initialize()
        {
            //model.PropertyChanged += ModelPropertyChanged;
        }
    }
}
