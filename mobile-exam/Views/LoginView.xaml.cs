using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using Firebase.Auth.Repository;
using mobile_exam.Models;
using mobile_exam.Services;

namespace mobile_exam.Views;

public partial class LoginView : ContentPage
{
    private readonly SignInModelView _signInModelView;
    public LoginView(SignInModelView signInModelView)
	{
		
		InitializeComponent();
        BindingContext = _signInModelView = signInModelView;

    }
}