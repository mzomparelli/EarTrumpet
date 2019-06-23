using System;
using System.Collections.Generic;

namespace EarTrumpet.UI.Helpers
{
    class LazyLoadCache<Key, T>
    {
        private readonly Dictionary<Key, T> _cache = new Dictionary<Key, T>();
        private readonly Func<Key, T> _create;

        public LazyLoadCache(Func<Key, T> create)
        {
            _create = create;
        }

        public T Resolve(Key key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = _create(key);
            }
            return _cache[key];
        }
    }
}
