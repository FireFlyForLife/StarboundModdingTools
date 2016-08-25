using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileListener.Interfaces
{
    public interface ISwitchable : IStartable, IStoppable
    {
        bool IsRunning();
    }

    public interface IStartable
    {
        void Start();
    }

    public interface IStoppable
    {
        void Stop();
    }
}
