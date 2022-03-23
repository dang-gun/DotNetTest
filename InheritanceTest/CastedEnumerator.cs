using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InheritanceTest
{
    public class CastedEnumerator<TTo, TFrom> : IEnumerator<TTo>
    {
        public IEnumerator<TFrom> BaseEnumerator;
        

        public CastedEnumerator(IEnumerator<TFrom> baseEnumerator)
        {
            BaseEnumerator = baseEnumerator;
        }

        // IDisposable
        public void Dispose() { BaseEnumerator.Dispose(); }

        // IEnumerator
        object IEnumerator.Current { get { return BaseEnumerator.Current; } }
        public bool MoveNext() { return BaseEnumerator.MoveNext(); }
        public void Reset() { BaseEnumerator.Reset(); }

        // IEnumerator<>
        public TTo Current { get { return (TTo)(object)BaseEnumerator.Current; } }

		
	}
}
