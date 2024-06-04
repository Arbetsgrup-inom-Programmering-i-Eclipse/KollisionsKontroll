using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;

namespace KollisionsKontroll
{
    public class ValidateAndRun
    {
        public static void Run(PlanSetup plan)
        {
            MainForm.Main(plan);
        }
    }
}
