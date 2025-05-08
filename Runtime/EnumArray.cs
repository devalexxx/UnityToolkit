using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityToolkit.Attributes;
using UnityEngine;

namespace UnityToolkit
{
    public class EnumArray 
    {

    }

    [Serializable]
    public class EnumArray<TKey, TValue> : EnumArray, IEnumerable<TValue> where TKey : Enum
    {
        private static readonly bool _isTValueConcrete = typeof(TValue).IsAbstract || typeof(TValue).IsInterface;

        [SerializeField]
        private List<TValue> _valArray = _isTValueConcrete ? null : new(Enumerable.Repeat<TValue>(default, Enum.GetValues(typeof(TKey)).Length));

        [SerializeReference, SubclassPicker]
        private List<TValue> _refArray = _isTValueConcrete ? new(Enumerable.Repeat<TValue>(default, Enum.GetValues(typeof(TKey)).Length)) : null;

        private List<TValue> _array
        {
            get => _isTValueConcrete ? _refArray : _valArray;
            set
            {
                if (_isTValueConcrete)
                    _refArray = value;
                else
                    _valArray = value;
            }
        }

        public EnumArray()
        {
            _array = new(Enumerable.Repeat<TValue>(default, Enum.GetValues(typeof(TKey)).Length));
        }

        public EnumArray(Func<TValue> p_cst)
        {
            for (int i = 0; i < _array.Count; i++)
            {
                _array[i] = p_cst();
            }
        }

        public EnumArray(Func<TKey, TValue> p_cst)
        {
            foreach ((TKey t_key, int t_index) in Enum.GetValues(typeof(TKey)).Cast<TKey>().Enumerate())
            {
                _array[t_index] = p_cst(t_key);
            }
        }

        public TValue this[TKey p_key]
        {
            get => _array[(int)(object)p_key];
            set => _array[(int)(object)p_key] = value;
        }

        public struct Enumerator : IEnumerator<TValue>
        {
            private TValue[] _array;
            private int      _index;

            public Enumerator(TValue[] p_array)
            {
                _array = p_array;
                _index = -1;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _array.Length;
            }

            public TValue Current => _array[_index];
            object IEnumerator.Current => Current;

            public void Reset()
            {
                _index = -1;
            }

            public void Dispose()
            {

            }
        }

        public IEnumerator<TValue> GetEnumerator() => new Enumerator(_array.ToArray());
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class EnumArrayExtensions
    {
        public static EnumArray<K, V> Select<F, K, V>(this EnumArray<K, F> self, Func<F, V> selector) where K: Enum
        {
            EnumArray<K, V> t_ret = new();
            foreach (var (i, v) in self.Select<F, (int, F)>((v, i) => (i, v)))
            {
                t_ret[(K)Enum.ToObject(typeof(K), i)] = selector(v);
            }
            return t_ret;
        }

        public static EnumArray<K, V> Select<F, K, V>(this EnumArray<K, F> self, Func<K, F, V> selector) where K: Enum
        {
            EnumArray<K, V> t_ret = new();
            foreach (var (i, v) in self.Select<F, (int, F)>((v, i) => (i, v)))
            {
                var t_key = (K)Enum.ToObject(typeof(K), i);
                t_ret[t_key] = selector(t_key, v);
            }
            return t_ret;
        }

        public static void ForEach<K, V>(this EnumArray<K, V> self, Action<K, V> func) where K: Enum
        {
            foreach (var (i, v) in self.Select<V, (int, V)>((v, i) => (i, v)))
            {
                func((K)Enum.ToObject(typeof(K), i), v);
            }
        }
    }

}
