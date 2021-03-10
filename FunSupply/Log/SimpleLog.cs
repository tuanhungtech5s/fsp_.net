using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSupply.Log
{
    public abstract class SimpleLog
    {
        public abstract void Log(string message);

        public string currentTime()
        {
            return DateTime.Now.ToString("dd-MM-yyyy h:m:s");
        }

    }

    
    
}
