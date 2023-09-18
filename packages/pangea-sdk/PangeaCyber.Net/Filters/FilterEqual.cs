namespace PangeaCyber.Net.Filters
{
    ///
    public class FilterEqual<T> : FilterBase
    {
        ///
        public FilterEqual(string name, Filter map)
            : base(name, map)
        {
        }

        ///
        public void Set(T value)
        {
            Map[Name] = value;
        }

        ///
        public T? Get()
        {
            return (T?)Map[Name];
        }
    }
}
