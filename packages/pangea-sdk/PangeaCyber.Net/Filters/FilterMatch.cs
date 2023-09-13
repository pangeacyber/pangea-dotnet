namespace PangeaCyber.Net.Filters
{
    ///
    public class FilterMatch<T> : FilterEqual<T>
    {
        ///
        public FilterMatch(string name, Filter map)
            : base(name, map)
        {
        }

        ///
        public List<T>? GetContains()
        {
            string containsKey = Name + "__contains";
            if (Map.ContainsKey(containsKey) && Map[containsKey] is List<T> containsList)
            {
                return containsList;
            }
            return null;
        }

        ///
        public void SetContains(List<T> value)
        {
            string containsKey = Name + "__contains";
            Map[containsKey] = value;
        }

        ///
        public List<T>? GetIn()
        {
            string inKey = Name + "__in";
            if (Map.ContainsKey(inKey) && Map[inKey] is List<T> inList)
            {
                return inList;
            }
            return null;
        }

        ///
        public void SetIn(List<T> value)
        {
            string inKey = Name + "__in";
            Map[inKey] = value;
        }
    }
}
