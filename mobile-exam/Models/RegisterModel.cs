using mobile_exam.Generic;
using MobileExam.Entities.Register;
using MobileExam.Entities.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_exam.Models
{
    public class RegisterModel:BaseBinding
    {
        private ListService _selectedOptionService;

        public ListService selectedOptionService
        {
            get
            {
                return _selectedOptionService;
            }
            set
            {
                SetValue(ref _selectedOptionService, value);
            }

        }


        private FormRegister _oFormRegister;
        public FormRegister oFormRegister
        {
            get
            {
                return _oFormRegister;
            }
            set
            {
                SetValue(ref _oFormRegister, value);
            }
        }

        private ObservableCollection<ListService> _listService;

        public ObservableCollection<ListService> listService
        {
            get
            {
                return _listService;
            }
            set
            {
                SetValue(ref _listService, value);
            }
        }
    }
}
