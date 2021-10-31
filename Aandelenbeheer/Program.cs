using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aandelenbeheer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void MainGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Aandelenbeheer());
        }
        static void Main()

        {
            AandelenBeheerData.Rss rssdata = new AandelenBeheerData.Rss();

            rssdata.ConnectionString = AandelenBeheer.Properties.Settings.Default.AandelenBeheerConnectionString;

            rssdata.Bewaar("Titel", "Ik", "Geen", "http://", DateTime.Now);

        }
    }
}
