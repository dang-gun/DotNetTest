using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTest
{
    public static class ListExtensions
    {
        public static IList<TTo> CastList<TFrom, TTo>(this IList<TFrom> list)
        {
            return new CastedList<TTo, TFrom>(list);
        }
    }
}
