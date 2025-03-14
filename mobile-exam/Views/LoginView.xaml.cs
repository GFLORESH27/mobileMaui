using mobile_exam.Services;

namespace mobile_exam.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		
		InitializeComponent();
	}
    private void OnButtonClicked(object sender, EventArgs args)
    {
       
        RegisterService registerService = MauiProgram.ServiceProvider.GetService<RegisterService>();
        VeterinaryService veterinaryService = MauiProgram.ServiceProvider.GetService<VeterinaryService>();
        Navigation.PushAsync(new HomeView(registerService, veterinaryService));

    }
}