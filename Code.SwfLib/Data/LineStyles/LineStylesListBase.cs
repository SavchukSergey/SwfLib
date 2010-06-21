using System;
using System.Collections;
using System.Collections.Generic;

namespace Code.SwfLib.Data.LineStyles {
    public abstract class LineStylesListBase : IList<LineStyle> {

        protected readonly IList<LineStyle> _styles = new List<LineStyle>();

        public IEnumerator<LineStyle> GetEnumerator() {
            return _styles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _styles.GetEnumerator();
        }

        public void Add(LineStyle item) {
            if (IsValid(item)) _styles.Add(item);
            else throw new InvalidOperationException("Invalid line style type");
        }

        public void Clear() {
            _styles.Clear();
        }

        public bool Contains(LineStyle item) {
            return _styles.Contains(item);
        }

        public void CopyTo(LineStyle[] array, int arrayIndex) {
            _styles.CopyTo(array, arrayIndex);
        }

        public bool Remove(LineStyle item) {
            return _styles.Remove(item);
        }

        public int Count {
            get { return _styles.Count; }
        }

        public bool IsReadOnly {
            get { return _styles.IsReadOnly; }
        }

        public int IndexOf(LineStyle item) {
            return _styles.IndexOf(item);
        }

        public void Insert(int index, LineStyle item) {
            _styles.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _styles.RemoveAt(index);
        }

        public LineStyle this[int index] {
            get { return _styles[index]; }
            set {
                if (IsValid(value)) _styles[index] = value;
                else throw new InvalidOperationException("Invalid line style type");
            }
        }

        public abstract bool IsValid(LineStyle style);

    }
}
