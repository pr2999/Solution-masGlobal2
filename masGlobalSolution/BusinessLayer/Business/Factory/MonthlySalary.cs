﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Business.Factory
{
    public class MonthlySalary : Employees2
    {
        public override decimal AnualSalary()
        {
            return 1000;
        }
    }
}