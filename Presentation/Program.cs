using System;
using System.Windows.Forms;

namespace DecisionSystemForRealEastateInvestment.Presentation
{
    internal static class Program
    {

        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(new HomePage());
        }
    }
}