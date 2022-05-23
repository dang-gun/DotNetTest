using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbTest2
{
    public class DataModel2 : DataModel
    {
        [BsonId]
        public long idIndex { get; set; }

        public int TestInt { get; set; } = 0;
    }
}
