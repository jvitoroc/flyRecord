using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flyrecord
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 

        public const string SETTINGS_FILE_PATH = "settings.dat";
        public static FlyRecord flyRecord;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings.Instance.Sync();
            flyRecord = new FlyRecord();
            Settings.Instance.Reflect(flyRecord);

            Application.Run(flyRecord);
        }
    }
}
