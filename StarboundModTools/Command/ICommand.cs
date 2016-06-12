using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public interface ICommand
    {
        String Name { get; }
        String Description { get; }
        String Usage { get; }

        void Run(String[] args);
    }
}
