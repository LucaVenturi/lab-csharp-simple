namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {

        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> _data = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => _data.Count;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => _data[Tuple.Create(key1, key2)];
            set => _data[Tuple.Create(key1, key2)] = value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            return _data.Keys
                .Where(tuple => tuple.Item1.Equals(key1))
                .Select(tuple => Tuple.Create(tuple.Item2, _data[tuple]))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            return _data.Keys
                .Where(tuple => tuple.Item2.Equals(key2))
                .Select(tuple => Tuple.Create(tuple.Item1, _data[tuple]))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            return _data.Keys
                .Select(tuple => Tuple.Create(tuple.Item1, tuple.Item2, _data[tuple]))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach(var k1 in keys1.ToArray())
            {
                foreach(var k2 in keys2.ToArray())
                {
                    this[k1, k2] = generator(k1, k2);
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            // TODO: improve
            return base.Equals(other);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            return obj is Map2D<TKey1, TKey2, TValue> d &&
                   EqualityComparer<Dictionary<Tuple<TKey1, TKey2>, TValue>>.Default.Equals(_data, d._data);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_data);
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            // TODO: improve
            return base.ToString();
        }
    }
}
