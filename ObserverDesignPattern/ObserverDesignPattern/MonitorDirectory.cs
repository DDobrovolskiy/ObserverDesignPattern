using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    public class MonitorDirectory
    {
        private List<string> _file;
        private readonly string _directory;

        public MonitorDirectory(string directory)
        {
            _directory = directory;
        }

        public bool StartMonitor()
        {
            if(!Directory.Exists(_directory))
            {
                return false;
            }

            _file = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(_directory);
            foreach(FileInfo file in directoryInfo.GetFiles())
            {
                _file.Add(file.FullName);
            }

            return true;
        }

        public List<string> GetListDeleteFile ()
        {
            List<string> listDeleteFile = new List<string>();

            foreach(var file in _file.ToArray())
            {
                if(!File.Exists(file))
                {
                    _file.Remove(file);
                    listDeleteFile.Add(file);
                }
            }

            return listDeleteFile;
        }
    }
}
