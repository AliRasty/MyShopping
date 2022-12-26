using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Application
{
    public class OperationResult
    {
        public string Massage { get; set; }

        public bool IsSuccedded { get; set; }

        public OperationResult()
        {
            IsSuccedded=false;  
        }

        public OperationResult Succedded(string massage = "عملیات با موفقیت انجام شد.")
        {
            IsSuccedded = true;
            Massage = massage;
            return this;
        }

        public OperationResult Failed(string massage)
        {
            IsSuccedded = false;
            Massage = massage;
            return this;
        }
    }
}
