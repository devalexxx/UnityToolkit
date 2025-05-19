namespace UnityToolkit.Math
{
    public interface IAdd<T>
    {
        public T Add(T p_other);
    }

    public interface ISub<T>
    {
        public T Sub(T p_other);
    }

    public interface IMul<T>
    {
        public T Mul(T p_other);
    }

    public interface IDiv<T>
    {
        public T Div(T p_other);
    }

    public interface IArithmetic<T> :
        IAdd<T>,
        ISub<T>,
        IMul<T>,
        IDiv<T>
    {}    

    public interface INumber<T> :
        IArithmetic<T>
    {}    
}