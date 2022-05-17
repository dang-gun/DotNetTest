using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbAssist
{

    /// <summary>
    /// LiteDbContext 컨택스트 지원
    /// </summary>
    public class LiteDbDataSet<T>
    {
        public ILiteCollection<T> Table;


        public LiteDbDataSet(ILiteCollection<T> table)
        {
            this.Table = table;
        }

        public void Add(T data)
        {
            this.Table.Insert(data);
        }
    }
}
