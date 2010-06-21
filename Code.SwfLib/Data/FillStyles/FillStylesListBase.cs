using System;
using System.Collections;
using System.Collections.Generic;

namespace Code.SwfLib.Data.FillStyles {
    public abstract class FillStylesListBase : IList<FillStyle> {

        protected readonly IList<FillStyle> _styles = new List<FillStyle>();

        public IEnumerator<FillStyle> GetEnumerator() {
            return _styles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _styles.GetEnumerator();
        }

        public void Add(FillStyle item) {
            if (IsValid(item)) _styles.Add(item);
            else throw new InvalidOperationException("Invalid fill style type");
        }

        public void Clear() {
            _styles.Clear();
        }

        public bool Contains(FillStyle item) {
            return _styles.Contains(item);
        }

        public void CopyTo(FillStyle[] array, int arrayIndex) {
            _styles.CopyTo(array, arrayIndex);
        }

        public bool Remove(FillStyle item) {
            return _styles.Remove(item);
        }

        public int Count {
            get { return _styles.Count; }
        }

        public bool IsReadOnly {
            get { return _styles.IsReadOnly; }
        }

        public int IndexOf(FillStyle item) {
            return _styles.IndexOf(item);
        }

        public void Insert(int index, FillStyle item) {
            _styles.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _styles.RemoveAt(index);
        }

        public FillStyle this[int index] {
            get { return _styles[index]; }
            set {
                if (IsValid(value)) _styles[index] = value;
                else throw new InvalidOperationException("Invalid fill style type");
            }
        }

        public abstract bool IsValid(FillStyle style);

    }
}
