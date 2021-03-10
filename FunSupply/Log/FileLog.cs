using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunSupply.Log
{
    public class FileLog : SimpleLog
    {
        string file;
        public FileLog(string file = "")
        {
            if (file == "")
            {
                this.file = Application.StartupPath+"/logs/"+ DateTime.Now.ToString("dd-MM-yyyy")+".txt";
            }
            else
            {
                this.file = file;
            }
        }
        public override void Log(string message)
        {
            using (StreamWriter streamWriter = File.AppendText(this.file))
            {
                var stack = (new System.Diagnostics.StackTrace()).GetFrame(1);
                string line = stack.GetFileLineNumber().ToString();
                string method = stack.GetMethod().Name;
                string prefixMessage = string.Format("Line {0} - Method {1}", line, method);

                streamWriter.WriteLine(this.currentTime()+" " +prefixMessage + " Message: " + message + "\n");
                streamWriter.Close();
            }
        }
    }
}
