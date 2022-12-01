using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class MyList<T>
    {
        private T[] data = new T[8];
        private int Count { get; set; }

        private Func<T, T, bool> ComparisonStrategy { get; }

        public MyList()
        {

            Func<T, T, bool> coreComparisonStrategy;

            if (typeof(IEquatable<T>).IsAssignableFrom(typeof(T)))
                coreComparisonStrategy = (a, b) => ((IEquatable<T>)a).Equals(b);
            else if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                coreComparisonStrategy = (a, b) => ((IComparable<T>)a).CompareTo(b) == 0;
            else
                coreComparisonStrategy = (a, b) => a.Equals(b);

            if (typeof(T).IsValueType)
                this.ComparisonStrategy = coreComparisonStrategy;
            else
                this.ComparisonStrategy = (a, b) =>
                    (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
                    (!object.ReferenceEquals(a, null) && coreComparisonStrategy(a, b));
        }

        public void Add(T value)
        {
            if (this.data.Length == this.Count)
                Array.Resize<T>(ref this.data, this.data.Length * 2);
            this.data[this.Count++] = value;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.Count; i++)
                if (this.ComparisonStrategy(this.data[i], value))
                    return true;
            return false;
        }
    }

}