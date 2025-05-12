using System;
using UnityEngine;

namespace UnityToolkit
{
    // A serializable version of System.Guid
    [Serializable]
    public class GUID : IComparable, IComparable<GUID>, IEquatable<GUID>, IFormattable
    {
        [SerializeField]
        private string _repr;

        public GUID()
        {
            _repr = Guid.Empty.ToString();
        }

        public GUID(Guid p_guid)
        {
            _repr = p_guid.ToString();
        }

        public int CompareTo(object p_obj)
        {
            return Guid.Parse(_repr).CompareTo(p_obj);
        }

        public int CompareTo(GUID p_other)
        {
            return Guid.Parse(_repr).CompareTo(Guid.Parse(p_other._repr));
        }

        public bool Equals(GUID p_other)
        {
            return Guid.Parse(_repr) == Guid.Parse(p_other._repr);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _repr;
        }

        public static implicit operator Guid(GUID p_guid) => Guid.Parse(p_guid._repr);
        public static implicit operator GUID(Guid p_guid) => new(p_guid);
    }
}