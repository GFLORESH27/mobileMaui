using MobileExam.Entities.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace mobile_exam.Services
{
    public class VeterinaryService
    {
        private ObservableCollection<ListService> listService;

        private readonly HttpClient _httpClient;

        public VeterinaryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            listService = new ObservableCollection<ListService>();
        }

        public async Task<ObservableCollection<ListService>> listServices()
        {
            try
            {
               var response = await _httpClient.GetFromJsonAsync<List<ListService>>("api/Service");
                if(response != null)
                {
                    return new ObservableCollection<ListService>(response);
                }
                return new ObservableCollection<ListService>(response);
            }
            catch(Exception e)
            {
                return new ObservableCollection<ListService>();

            }
        }
    }
}
