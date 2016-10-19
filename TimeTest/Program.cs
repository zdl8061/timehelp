using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerHelper _timer = new TimerHelper();
           
            _timer.IsAtOnce = true;
            _timer.TimeDelay = 60 * 1000;
            _timer.Interval = 2000;
            _timer.Number = 5;
            _timer.Elapsed += (o, e) =>
            {
                Console.WriteLine("i");                
            };
            _timer.Elapsed += (o, e) =>
            {
                Console.WriteLine("t");
            };      

            _timer.Start();

            Console.ReadKey();
        }
    }
}
