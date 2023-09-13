namespace PangeaCyber.Net.Filters
{
    ///
    public class FilterBase
    {
        ///
        protected string Name;

        ///
        protected Filter Map;

        ///
        public FilterBase(string name, Filter map)
        {
            Name = name;
            Map = map;
        }
    }
}
