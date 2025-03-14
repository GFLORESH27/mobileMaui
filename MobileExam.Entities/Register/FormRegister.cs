using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileExam.Entities.Register
{
    public class FormRegister
    {
        public int idRegister { get; set; }
        public string petName { get; set; }
        public int idServicio { get; set; }
        public DateTime dateService { get; set; } = DateTime.Now;
    }
}
