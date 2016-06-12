using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public static class WinApi
    {
        [DllImport("win32")]//TODO: get correct names
        public static extern bool AttachConsole();
    }
}
