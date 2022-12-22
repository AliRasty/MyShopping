using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Domin
{
    public class EntetyBase
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public EntetyBase()
        {
            CreateDate = DateTime.Now;
        }
    }
}
