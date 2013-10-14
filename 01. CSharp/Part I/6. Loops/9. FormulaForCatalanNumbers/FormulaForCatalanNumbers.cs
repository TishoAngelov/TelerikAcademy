using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9.FormulaForCatalanNumbers
{
    static class FormulaForCatalanNumbers
    {        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CatalanNumbers());
        }
    }
}
