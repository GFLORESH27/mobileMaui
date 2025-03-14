using MobileExam.Entities.Register;
using MobileExam.Entities.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace mobile_exam.Services
{
    public class RegisterService
    {
        private ObservableCollection<ListRegister> listPetRecord;
        private readonly VeterinaryService veterinaryService;
        private readonly HttpClient _httpClient;

        public event Func<int, Task> OnGet;
        public event Func<Task> Onchange;
        public RegisterService(VeterinaryService _veterinaryService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            veterinaryService = _veterinaryService;
            listPetRecord = new ObservableCollection<ListRegister>();
        }

        public void notificarChange()
        {
            Onchange?.Invoke();
        }
        public async Task<ObservableCollection<ListRegister>> listPetRecords()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ListRegister>>("api/Register");
                if (response != null)
                {
                    return new ObservableCollection<ListRegister>(response);
                }
                return new ObservableCollection<ListRegister>(response);
            }
            catch (Exception e)
            {
                return new ObservableCollection<ListRegister>();

            }
        }

        public void notificarGet(int id)
        {
            OnGet?.Invoke(id);
        }

        public async Task<int> SaveRegisterPet(FormRegister oFormRegister)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Register", oFormRegister);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
               
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<FormRegister> searchregisterPetbyId(int idRegister)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<FormRegister>("api/Register/"+idRegister);
                if (response != null)
                {
                    return response;
                }
                return new FormRegister();
            }
            catch (Exception e)
            {
                return new FormRegister();

            }
        }

        public async Task<int> deleteRecordPet(int idRegister)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/Register/" + idRegister);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
