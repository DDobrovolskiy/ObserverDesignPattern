using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ObserverDesignPattern.Observer
{
    public class FileStatusEvent
    {
        public EventHandler<string> removeFile;
        private readonly Timer _timer;
        private readonly MonitorDirectory _monitorDirectory;

        public FileStatusEvent(string directory)
        {
            _monitorDirectory = new MonitorDirectory(directory);

            if (_monitorDirectory.StartMonitor())
            {
                _timer = new Timer(1000);
                _timer.Elapsed += TimerElapsed;
                _timer.Start();
            }
            else
            {
                Console.WriteLine("Directory exepted!");
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var filename in _monitorDirectory.GetListDeleteFile())
            {
                var eHandler = removeFile;
                eHandler?.Invoke(this, filename);
            }
        }
    }
}
