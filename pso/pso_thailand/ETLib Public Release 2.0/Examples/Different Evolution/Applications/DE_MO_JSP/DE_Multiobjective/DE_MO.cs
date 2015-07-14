using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETLib_MODE_JSP;

namespace DE_MutiObjective
{
    static class DE_MO
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            About.showAbout();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultiObjDE());
        }
    }
}