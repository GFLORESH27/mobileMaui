using mobile_exam.Models;
using mobile_exam.Services;
using MobileExam.Entities.Register;
using MobileExam.Entities.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace mobile_exam.Views;

public partial class RegistrationForm : ContentPage
{
    public RegisterModel oRegisterModel { get; set; }
    
    private readonly RegisterService registerService;
    private readonly VeterinaryService veterinaryService;

    public RegistrationForm(VeterinaryService _veterinaryService, RegisterService _registerService)
	{
		InitializeComponent();
        registerService = _registerService;
        registerService.OnGet += searchregisterPetbyId;
        veterinaryService = _veterinaryService;
        oRegisterModel = new RegisterModel();
        BindingContext = this;
        oRegisterModel.oFormRegister = new FormRegister();
        oRegisterModel.selectedOptionService = new ListService();
        listComboService();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        registerService.OnGet -= searchregisterPetbyId;
    }

    private async Task searchregisterPetbyId(int idRegister)
    {
            FormRegister objregister = await registerService.searchregisterPetbyId(idRegister);
            oRegisterModel.oFormRegister = objregister;
            oRegisterModel.selectedOptionService = oRegisterModel.listService.FirstOrDefault(x => x.idServicio == oRegisterModel.oFormRegister.idServicio);   
    }

    private async Task listComboService()
    {
        var listService = await veterinaryService.listServices();
        oRegisterModel.listService = listService;
    }

    public async void BtnGuardar_Clicked(object sender, EventArgs e)
    {
        bool saveconfirmation = await DisplayAlert("Confirmación", "Desea realmente guardar el registro?", "Si", "No");
        if (saveconfirmation)
        {
            FormRegister obForm = oRegisterModel.oFormRegister;
            obForm.idServicio = oRegisterModel.selectedOptionService.idServicio;
            int resp = await registerService.SaveRegisterPet(obForm);
            if (resp == 0)
            {
                await DisplayAlert("Error", "No se guardo el registro", "Salir");
            }
            else
            {
                await DisplayAlert("Exito", "Se guardo el registro", "Salir");
                RegisterService registerService = MauiProgram.ServiceProvider.GetService<RegisterService>();
                VeterinaryService veterinaryService = MauiProgram.ServiceProvider.GetService<VeterinaryService>();
                await Navigation.PushAsync(new HomeView(registerService, veterinaryService));                
            }
        }
    }

    private void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}