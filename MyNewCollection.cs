using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab12;
using Lab_10;

namespace Lab_13
{
    public class MyNewCollection<T> : MyCollection<T>, ICloneable, IEnumerable<T> where T : IEquatable<T>
    {

    
        public string Name { get; set; }
      
        public List<T> Node
        {
            set
            {
                for (int i = 0; i < list.Count; i++)
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(Name, "changed", new T[] { list[i] }));
            }
        }
        public MyNewCollection(string name)
        {
            Name = name;
        }
        public event EventHandler<CollectionHandlerEventArgs<T>> OnCollectionCountChanged = delegate { };
        public event EventHandler<CollectionHandlerEventArgs<T>> OnCollectionReferenceChanged = delegate { };
        public override void Add_element(T data)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, " Add(T obj) ", new T[] {data})) ;
            base.Add_element(data);
        }

        public override void Add_Range(List<T> Collection)
        {
            T[] arr = new T[Collection.Count];
            Collection.CopyTo(arr);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, " Add Range(List<T> list) ",arr));
            base.Add_Range(Collection);
        }
        public override void Delete_element(T data)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, " Delete(T obj) ", new T[]{ data }));
            base.Delete_element(data);
        }
        public virtual void DeleteRange(int start,int count,List<T>collention)
        {
            T[] arr = new T[collention.Count];
            collention.CopyTo(arr);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, " Delete Range(List<T>) ", arr));
            base.Delete_Range(start, count);
        }

        public void Change(T data)
        {
            OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(Name, "changed", new T[] { data }));
            list[0]= data ;
        }
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

}