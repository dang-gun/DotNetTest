using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbTest
{

    public static class LiteDbSupport
    {
        public LiteDatabase Context()
        {
            return new LiteDatabase(@"MyData.db");
        }

    }
}
