using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Manager
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
    public static class SetDat
    {
        public delegate void SetData(string name);
        public static SetData EventHandler;

    }
    public static class GetDat
    {
        public delegate void GetData(string name, DialogResult dr);
        public static GetData EventHandler;

    }
}
