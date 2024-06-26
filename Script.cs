﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS
{
    public class Script
    {
        private VMS.TPS.Common.Model.API.Application app;

        public void Execute(ScriptContext scriptContext)
        {
            KollisionsKontroll.ValidateAndRun.Run(scriptContext.PlanSetup);
        }
    }
}
