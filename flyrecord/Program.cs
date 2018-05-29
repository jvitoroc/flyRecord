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

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs;
            flyRecord = new FlyRecord();
            if (!File.Exists(SETTINGS_FILE_PATH))
            {
                fs = new FileStream(SETTINGS_FILE_PATH, FileMode.Create);
                formatter.Serialize(fs, Configuration.Instance);
            }
            else
            {
                fs = new FileStream(SETTINGS_FILE_PATH, FileMode.Open);
                if(fs.Length != 0)
                    Configuration.Instance = (Configuration)formatter.Deserialize(fs);
            }
            fs.Dispose();
            fs.Close();
            formatter = null;
            Configuration.Instance.Reflect(flyRecord);

            Application.Run(flyRecord);
        }
    }
}
