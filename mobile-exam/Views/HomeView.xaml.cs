using mobile_exam.Services;
using MobileExam.Entities.Register;
using MobileExam.Entities.Services;
using System.Collections.ObjectModel;

namespace mobile_exam.Views;

public partial class HomeView : ContentPage
{
    public ObservableCollection<ListService> listService { get; set; }

    public ObservableCollection<ListRegister> listRegister { get; set; }
    private ObservableCollection<ListRegister> listafiltro;

    public string petName { get; set; }

    public ListRegister objSeleccionado { get; set; }

    public ListService oListService { get; set; }

    private VeterinaryService veterinaryService;
    private RegisterService registerService;
    public HomeView(RegisterService _registerService, VeterinaryService _veterinaryService)
	{
		InitializeComponent();
        veterinaryService = _veterinaryService;
        registerService = _registerService;
        registerService.Onchange += refrezcarLista;
        listRegister = new ObservableCollection<ListRegister>();
        listRegisterPet();

        listafiltro = new ObservableCollection<ListRegister>(listRegister);
        BindingContext = this;
    }

    private async Task refrezcarLista()
    {
        await listRegisterPet();
    }

    public async Task listRegisterPet()
    {
        var listaop = await registerService.listPetRecords();
        listRegister.Clear();
        foreach (var pet in listaop)
        {
            listRegister.Add(pet);
        }
        listafiltro = new ObservableCollection<ListRegister>(listRegister);
    }


    private void lst_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var instancia = new RegistrationForm(veterinaryService, registerService);
        int idregister = objSeleccionado.idRegister;
        registerService.notificarGet(idregister);
        Navigation.PushAsync(instancia);
    }

    private async void swipeItemEliminar_Invoked(object sender, EventArgs e)
    {
        bool deleteConfirmation = await DisplayAlert("Confirmación", "Desea realmente eliminar el registro?", "Si", "No");
        if (deleteConfirmation)
        {
            SwipeItem oSwipeItem = (SwipeItem)sender;
            ListRegister oListRegister = (ListRegister)oSwipeItem.BindingContext;
            int response = await registerService.deleteRecordPet(oListRegister.idRegister);
            if (response == 1)
            {
                DisplayAlert("Exito", "Registro eliminado", "Salir");
                await listRegisterPet();
            }
            else
            {
                DisplayAlert("Error", "No se pudo eliminar", "Salir");
            }
        }
        
    }

    private void OnButtonClicked(object sender, EventArgs args)
    {
        RegisterService registerService = MauiProgram.ServiceProvider.GetService<RegisterService>();
        VeterinaryService veterinaryService = MauiProgram.ServiceProvider.GetService<VeterinaryService>();
        Navigation.PushAsync(new RegistrationForm(veterinaryService, registerService));

    }

    private void searchName_TextChanged(object sender, TextChangedEventArgs e)
    {
        //if (petName == null || petName == "")
        //{
        //    listRegister.Clear();
        //    foreach (var pet in listafiltro)
        //    {
        //        listRegister.Add(pet);
        //    }
        //}
        ObservableCollection<ListRegister> listaop;
        listRegister.Clear();
        if (petName == null || petName == "")
        {
            listaop = listafiltro;
        }
        else
        {
            var listafiltroPet = listafiltro.Where(p => p.petName.ToUpper()
            .Contains(petName.ToUpper())).ToList();
            listaop = new ObservableCollection<ListRegister>(listafiltroPet);
        }
        foreach (var pet in listaop)
        {
            listRegister.Add(pet);
        }

    }

    public void searchName_SearchButtonPressed(object sender, EventArgs e)
    {
        ObservableCollection<ListRegister> listaop;
        listRegister.Clear();
        if(petName == null || petName == "")
        {
            listaop = listafiltro;
        }
        else
        {
            var listafiltroPet = listafiltro.Where(p => p.petName.ToUpper()
            .Contains(petName.ToUpper())).ToList();
            listaop = new ObservableCollection<ListRegister>(listafiltroPet);
        }
        foreach (var pet in listaop)
        {
            listRegister.Add(pet);
        }
    }
}