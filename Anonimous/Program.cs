using System;
using System.Windows.Forms;
namespace Anonimous
{
    //delegate void DisplayMessage(string message);

    public class TestCustomDelegate
    {
        public static void Main()
        {
            //DisplayMessage messageTarget;
            Action<string> messageTarget;
            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
        }

        private static void ShowWindowsMessage(string message)
        {
            MessageBox.Show(message,"Warnig Alert",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
