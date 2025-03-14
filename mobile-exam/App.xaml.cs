using mobile_exam.Views;

namespace mobile_exam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView());

        }

    }
}