using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using mobile_exam.Models;
using mobile_exam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_exam.Views
{
    public partial class SignInModelView : ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        [ObservableProperty]
        private SignInModel signInModel = new();

        [ObservableProperty]
        private string _errorMessage;

        public SignInModelView(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
        }

        [RelayCommand]
        private async Task SignIn()
        {
            try
            {
                var result = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(signInModel.Email, signInModel.Password);
                if (!string.IsNullOrWhiteSpace(result?.User?.Info?.Email))
                {
                    await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
                }

            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }



        }

    }
}
