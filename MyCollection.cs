using System;
using System.Collections;
using System.Collections.Generic;
namespace lab12
{
    public class MyCollection<T> : MyEnumerator<T>, IEnumerable<T>
    {
        public MyCollection() : base() { }
        public MyCollection(int c) : base(c) { }
        public MyCollection(List<T> collection) : base(collection) { }
        public MyCollection(T data) : base(data){ }
        public virtual void Add_element(T data)
        {
            this.list.Add(data);
            this.index++;
        }
        public virtual void Add_Range(List<T> collection)
        {
            list.AddRange(collection);
            index += collection.Count;
        }
        public virtual void Delete_element(T data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            else
            {
                list.Remove(data);
                index--;
            }
        }
        public virtual void Delete_Range(int start, int count)
        {
            if (this.list == null)
                throw new ArgumentNullException("data");
            else
            {
                list.RemoveRange(start, count);
                index -= count;

            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (this.list != null)
                return list.GetEnumerator();
            else
                return new MyEnumerator<T>();
        }

        public bool Search(T data)
        {
            if (this.list == null)
            {
                return false;
                throw new ArgumentNullException("data");
            }
            else
            {
                if (list.Contains(data))
                    Console.WriteLine("Found" + data);
                return true;
            }
        }

        public void Copy(T[] arr)
        {
            this.list.CopyTo(arr);

        }
        public void GetEnumerator(List<T> collection)
        {
            if (this.list != null)
            {
                IEnumerator<T> enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                    collection.Add(enumerator.Current);
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in list)
                yield return item;
        }
    }

}

