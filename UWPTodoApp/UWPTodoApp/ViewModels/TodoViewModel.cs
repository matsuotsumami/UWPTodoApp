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
    public class TodoViewModel : Observable
    {
        private Models.UserModel userModel = DataModelService.Instance().UserModel;


    }
}
