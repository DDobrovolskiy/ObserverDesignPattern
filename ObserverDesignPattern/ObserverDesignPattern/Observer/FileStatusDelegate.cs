using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ObserverDesignPattern.Observer
{
    public class FileStatusDelegate
    {
        private readonly Action<string> _subscriber;
        private readonly Timer _timer;
        private readonly MonitorDirectory _monitorDirectory;

        public FileStatusDelegate(string directory, Action<string> subscriber)
        {
            _subscriber = subscriber;
            _monitorDirectory = new MonitorDirectory(directory);

            if(_monitorDirectory.StartMonitor())
            {
                _timer = new Timer(1000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
            else
            {
                Console.WriteLine("Directory exepted!");
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach(var filename in _monitorDirectory.GetListDeleteFile())
            {
                _subscriber(filename);
            }
        }
    }
}
