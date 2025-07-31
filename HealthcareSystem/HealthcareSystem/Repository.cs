using System;
using System.Collections.Generic;

namespace HealthcareSystem
{
    public class Repository<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T? GetById(Func<T, bool> predicate)
        {
            foreach (var item in _items)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }

        public bool Remove(Func<T, bool> predicate)
        {
            var item = GetById(predicate);
            if (item != null)
            {
                _items.Remove(item);
                return true;
            }
            return false;
        }
    }
}
