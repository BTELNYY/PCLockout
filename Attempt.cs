using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace PCLockout
{
    public class Attempt
    {
        public DateTime time;
        public string wrongpassword;
        public bool resetattempted;
    }
}
