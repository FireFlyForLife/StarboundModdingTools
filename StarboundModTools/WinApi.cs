using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public static partial class WinApi
    {
        //MAYBE: Split all p/Invokes in their own file, but in the same partial class.
        //[DllImport("kernel32", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool AttachConsole(int dwProcess);
    }
}
