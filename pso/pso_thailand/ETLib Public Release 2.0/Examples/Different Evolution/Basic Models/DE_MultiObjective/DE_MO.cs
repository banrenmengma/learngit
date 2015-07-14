using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETLib_MODE;

namespace DE_MultiObjective
{
    static class DE_MO
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultiObjDE());
        }
    }
}