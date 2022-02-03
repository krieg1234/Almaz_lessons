using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_lessons_app
{
    class Logger
    {
        private StreamWriter sw = new StreamWriter("log.txt", true, Encoding.Default);
                
        public void WriteLog(Object[] data, string header)
        {            
            string date = DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture);
            try
            {
                using (sw)
                {
                    sw.WriteLine($"\n\n{date} {header}");
                    foreach (var item in data)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
                
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
