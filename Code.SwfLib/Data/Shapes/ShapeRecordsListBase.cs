using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.SwfLib.Data.Shapes {
    public abstract class ShapeRecordsListBase : IList<ShapeRecord> {

        protected readonly IList<ShapeRecord> _records = new List<ShapeRecord>();

        public IEnumerator<ShapeRecord> GetEnumerator() {
            return _records.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _records.GetEnumerator();
        }

        public void Add(ShapeRecord item) {
            if (IsValid(item)) {
                _records.Add(item);
            } else {
                throw new InvalidOperationException("Unsupported shape record type");
            }
        }

        public void Clear() {
            _records.Clear();
        }

        public bool Contains(ShapeRecord item) {
            return _records.Contains(item);
        }

        public void CopyTo(ShapeRecord[] array, int arrayIndex) {
            _records.CopyTo(array, arrayIndex);
        }

        public bool Remove(ShapeRecord item) {
            return _records.Remove(item);
        }

        public int Count {
            get { return _records.Count; }
        }

        public bool IsReadOnly {
            get { return _records.IsReadOnly; }
        }

        public int IndexOf(ShapeRecord item) {
            return _records.IndexOf(item);
        }

        public void Insert(int index, ShapeRecord item) {
            _records.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _records.RemoveAt(index);
        }

        public ShapeRecord this[int index] {
            get { return _records[index]; }
            set {
                if (IsValid(value)) {
                    _records[index] = value;
                } else {
                    throw new InvalidOperationException("Unsupported shape record type");
                }
            }
        }

        public abstract bool IsValid(ShapeRecord item);

    }
}
