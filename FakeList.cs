using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace List
{
    public class FakeList<T> : IEquatable<FakeList<T>>, IEnumerable<T>, ICollection<T>, IList<T>
        where T : IEquatable<T>
    {
        T[] items;
        int cap;
        int size;
        public int Count
        {
            get { return size; }
        }

        public bool IsReadOnly => false;

        public T this[int index] { get => items[index]; set => throw new NotImplementedException(); }

        public FakeList(int capacity = 10)
        {
            cap = capacity;
            items = new T[cap];
            size = 0;
        }

        private void Resize(bool inc = true)
        {
            if (inc)
                cap *= 2;
            else
                cap /= 2;
            T[] newItems = new T[cap];
            for (int i = 0; i < size; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }

        public void Add(T item)
        {
            if (size == cap)
            {
                Resize();
            }
            items[size++] = item;
        }

        public void RemoveAt(int b)
        {
            --size;
            for (int i = b; i < size; i++)
            {
                items[i] = items[i + 1];
            }
            if (size < cap / 2) Resize(false);
        }

        public void Clear()
        {
            size = 0;
        }

        public void Insert(int index, T item)
        {
            if (size == cap)
            {
                Resize();
            }
            for (int i = size - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
            items[index] = item;
            ++size;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1; 
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }


        public override bool Equals(object? obj) => this.Equals(obj as FakeList<T>);

        public bool Equals(FakeList<T>? other)
        {
            if (other is null) {
                return false;
            }

            if (Object.ReferenceEquals(this, other)) {
                return true;
            }

            if (this.GetType() != other.GetType()) {
                return false;
            }

            if (this.Count != other.Count) {
                return false;
            }

            if (this.Count == 0) {
                return true;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (!this.items[i].Equals(other.items[i])) {
                    return false;
                }
            }
            return true;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++) {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length) {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length < size - arrayIndex) {
                throw new ArgumentException("Not enough space in the target array.");
            }
            for (int i = 0; i < size; i++)
            {
                array[arrayIndex + i] = items[i];
            }
        }


        public override int GetHashCode()
        {
            int prime = 31;
            int hash = 17;
            for (int i = 0; i < size; i++)
            {
                hash = hash * prime + (items[i] == null ? 0 : items[i].GetHashCode());
            }
            return hash;
        }
    }
}
