using System;
using System.Runtime.InteropServices;

namespace Bot.Worker
{
   

        [Flags]
        internal enum ErrorModes : uint
        {
            /// <summary>
            ///Use the system default, which is to display all error dialog boxes.
            /// </summary>
            SYSTEM_DEFAULT = 0x0,

            /// <summary>
            ///The system does not display the critical-error-handler message box. Instead, the system sends the error to the calling process.
            ///Best practice is that all applications call the process-wide SetErrorMode function with a parameter of SEM_FAILCRITICALERRORS at startup. This is to prevent error mode dialogs from hanging the application.
            ///SEM_NOALIGNMENTFAULTEXCEPT
            /// </summary>
            SEM_FAILCRITICALERRORS = 0x0001,

            /// <summary>
            ///The system automatically fixes memory alignment faults and makes them invisible to the application. It does this for the calling process and any descendant processes. This feature is only supported by certain processor architectures. For more information, see the Remarks section.
            ///After this value is set for a process, subsequent attempts to clear the value are ignored.
            /// </summary>
            SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,

            /// <summary>
            /// The system does not display the Windows Error Reporting dialog.
            /// </summary>
            SEM_NOGPFAULTERRORBOX = 0x0002,

            /// <summary>
            /// The system does not display a message box when it fails to find a file. Instead, the error is returned to the calling process.
            /// </summary>
            SEM_NOOPENFILEERRORBOX = 0x8000
        }

        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern ErrorModes SetErrorMode(ErrorModes mode);
        }
    }

