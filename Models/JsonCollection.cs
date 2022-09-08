using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PandaDocDotNetSDK.Models
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1168:Empty arrays and collections should be returned instead of null", Justification = "Empty arrays and collections will Serialize, Null will *not* Serialize")]
    public class JsonCollection<T> : Collection<T>
    {

        //
        // Constructors
        //

        public JsonCollection() : base()
        {
        }

        public JsonCollection(T item) : base(new Collection<T> { item })
        {
        }

        public JsonCollection(JsonCollection<T> collection) : base(new Collection<T>(collection))
        {
        }

        public JsonCollection(IList<T> list) : base(new Collection<T>(list))
        {
        }

        //
        // Methods
        //

        public bool ShouldSerialize()
        {
            return (Count > 0);
        }

        // Return Object-List as a Collection, to support Json formatting use-cases
        public JsonCollection<T>? ToJsonCollection()
        {
            if (ShouldSerialize())
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        // Return Object-List as an Array, to support Json formatting use-cases
        public T[]? ToArray()
        {
            if (ShouldSerialize())
            {
                return ToArray();
            }
            else
            {
                return null;
            }
        }

        // Return Object-List as a List, to support Json formatting use-cases
        public List<T>? ToList()
        {
            if (ShouldSerialize())
            {
                return ToList();
            }
            else
            {
                return null;
            }
        }

        public void Set()
        {
            Clear();
        }

        public void Set(T item)
        {
            Clear();
            if (item != null)
            {
                Add(item);
            }
        }

        public void Set(Collection<T> collection)
        {
            Clear();
            if ((collection != null) && (collection.Count > 0))
            {
                foreach (T item in collection)
                {
                    if (item != null)
                    {
                        Add(item);
                    }
                }
            }
        }

        public void Set(JsonCollection<T> collection)
        {
            Clear();
            if ((collection != null) && (collection.Count > 0))
            {
                foreach (T item in collection)
                {
                    if (item != null)
                    {
                        Add(item);
                    }
                }
            }
        }

        public void Set(IList<T> list)
        {
            Clear();
            if ((list != null) && (list.Count > 0))
            {
                foreach (T item in list)
                {
                    if (item != null)
                    {
                        Add(item);
                    }
                }
            }
        }

    } // class JsonCollection<T>

} // namespace
