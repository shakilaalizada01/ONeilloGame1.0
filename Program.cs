using System;
using System.Windows.Forms;

namespace O_Neillo_Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create instances of your classes
          
            Form1 mainForm = new Form1();
            

            // Set up event handlers or any other initialization logic

            Application.Run(mainForm);
        }
    }
}
