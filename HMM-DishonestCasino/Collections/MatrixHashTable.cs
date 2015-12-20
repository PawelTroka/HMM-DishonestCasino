#define _USE_DICTIONARY_WITHIN_DICTIONARY
using System;
using System.Collections.Generic;

namespace HMMDishonestCasino.Collections
{
    public class MatrixHashTable<TKey1, TKey2, TValue>
    {
        public int GetLength(int i)
        {
            if (i == 0)
                return _k1SpaceCount;
            if (i == 1)
                return _k2SpaceCount;
            throw new ArgumentException();
        }

        private readonly int _k1SpaceCount;
        private readonly int _k2SpaceCount;

        public MatrixHashTable(IReadOnlyCollection<TKey1> k1Space, IReadOnlyCollection<TKey2> k2Space)
        {
            _k1SpaceCount = k1Space.Count;
            _k2SpaceCount = k2Space.Count;
#if _USE_DICTIONARY_WITHIN_DICTIONARY
            _dict = new Dictionary<TKey1, Dictionary<TKey2, TValue>>(k1Space.Count);

            foreach (var k1 in k1Space)
            {
                _dict[k1] = new Dictionary<TKey2, TValue>(k2Space.Count);
            }
#else
            _dict = new Dictionary<Pair<TKey1, TKey2>, TValue>(k1Space.Count * k2Space.Count);
#endif
        }

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get
            {
#if _USE_DICTIONARY_WITHIN_DICTIONARY
                return _dict[key1][key2];
#else
                return _dict[new Pair<TKey1, TKey2>(key1, key2)];
#endif
            }

            set
            {
#if _USE_DICTIONARY_WITHIN_DICTIONARY
                _dict[key1][key2] = value;
#else
                _dict[new Pair<TKey1, TKey2>(key1, key2)] = value;
#endif
            }
        }

#if _USE_DICTIONARY_WITHIN_DICTIONARY
        private readonly Dictionary<TKey1, Dictionary<TKey2, TValue>> _dict;
#else
        private readonly Dictionary<Pair<TKey1, TKey2>, TValue> _dict;
#endif

#if !_USE_DICTIONARY_WITHIN_DICTIONARY
        private struct Pair<TK1, TK2>
        {
            private readonly TK1 key1;
            private readonly TK2 key2;

            public override int GetHashCode()
            {
                return key1.GetHashCode() ^ key2.GetHashCode();
            }

            public Pair(TK1 k1, TK2 k2)
            {
                key1 = k1;
                key2 = k2;
            }
        }
#endif
    }
}