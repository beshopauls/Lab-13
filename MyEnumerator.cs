using System;
using System.Collections;
using System.Collections.Generic;


namespace lab12
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        public List<T> list;
        public int index;
        public MyEnumerator()
        {
            list = new List<T>();
            index = -1;
        }
        public MyEnumerator(T data)
        {
            list = new List<T>();
            list.Add(data);
            index++;
        }
        public MyEnumerator(int c)
        {
            list = new List<T>(c);
            index = c;
        }
        public MyEnumerator(List<T> collection)
        {
            this.list = collection;

            index = collection.Count;

        }
      
        public T Current
        {
            get
            {
                if (index == -1 || index > list.Count)
                    throw new IndexOutOfRangeException();
                else
                    return list[index];
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }
            else return false;
        }
        public void Reset()
        {
            index = -1;
            this.list = null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
