namespace UnityToolkit.Math
{
    public readonly struct Int32 : INumber<Int32>
    {
        private readonly int _value;

        public Int32(int p_value)
        {
            _value = p_value;
        }

        public Int32 Add(Int32 p_other)
        {
            return _value + p_other._value;
        }

        public Int32 Sub(Int32 p_other)
        {
            return _value - p_other._value;
        }

        public Int32 Mul(Int32 p_other)
        {
            return _value * p_other;
        }

        public Int32 Div(Int32 p_other)
        {
            return _value / p_other._value;
        }

        public static implicit operator Int32(int   p_value) => new(p_value);
        public static implicit operator int  (Int32 p_value) => p_value._value;
    }

    public readonly struct Int64 : INumber<Int64>
    {
        private readonly long _value;

        public Int64(long p_value)
        {
            _value = p_value;
        }

        public Int64 Add(Int64 p_other)
        {
            return _value + p_other._value;
        }

        public Int64 Sub(Int64 p_other)
        {
            return _value - p_other._value;
        }

        public Int64 Mul(Int64 p_other)
        {
            return _value * p_other;
        }

        public Int64 Div(Int64 p_other)
        {
            return _value / p_other._value;
        }

        public static implicit operator Int64(long  p_value) => new(p_value);
        public static implicit operator long (Int64 p_value) => p_value._value;
    }

    public readonly struct Float32 : INumber<Float32>
    {
        private readonly float _value;

        public Float32(float p_value)
        {
            _value = p_value;
        }

        public Float32 Add(Float32 p_other)
        {
            return _value + p_other._value;
        }

        public Float32 Sub(Float32 p_other)
        {
            return _value - p_other._value;
        }

        public Float32 Mul(Float32 p_other)
        {
            return _value * p_other;
        }

        public Float32 Div(Float32 p_other)
        {
            return _value / p_other._value;
        }

        public static implicit operator Float32(float    p_value) => new(p_value);
        public static implicit operator float   (Float32 p_value) => p_value._value;
    }

    public readonly struct Float64 : INumber<Float64>
    {
        private readonly double _value;

        public Float64(double p_value)
        {
            _value = p_value;
        }

        public Float64 Add(Float64 p_other)
        {
            return _value + p_other._value;
        }

        public Float64 Sub(Float64 p_other)
        {
            return _value - p_other._value;
        }

        public Float64 Mul(Float64 p_other)
        {
            return _value * p_other;
        }

        public Float64 Div(Float64 p_other)
        {
            return _value / p_other._value;
        }

        public static implicit operator Float64(double  p_value) => new(p_value);
        public static implicit operator double (Float64 p_value) => p_value._value;
    }
}