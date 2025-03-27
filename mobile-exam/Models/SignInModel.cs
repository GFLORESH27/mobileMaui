using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using mobile_exam.Services;
using mobile_exam.Views;

namespace mobile_exam.Models
{
    public class SignInModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
