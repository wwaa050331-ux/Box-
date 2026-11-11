using System;
using System.Windows.Forms;

namespace BOX.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new ParcelForm("user01"));
        }
    }
}
