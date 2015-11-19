using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace BAL.Context
{
    class DataBaseContext : System.Data.Entity.DbContext
    {
        public DataBaseContext() : base("CompanyDatabase") { }
    }
}
