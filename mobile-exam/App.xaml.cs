using Firebase.Auth;
using mobile_exam.Models;
using mobile_exam.Views;

namespace mobile_exam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

    }
}