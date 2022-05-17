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
    public static class LiteDbGlobal
    {
        /// <summary>
        /// 1회용 컨택스트를 만들어 리턴한다.
        /// </summary>
        /// <returns></returns>
        public static LiteDbContext Context()
        {
            return new LiteDbContext(@"MyData.db");
        }

    }
}
