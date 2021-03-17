using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Sass.Storage
{
    public class DbConnectionConfig : ConnectionConfig
    {
        public bool PrintLog { get; set; }
    }
}
