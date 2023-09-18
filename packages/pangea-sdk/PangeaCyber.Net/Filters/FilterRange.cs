namespace PangeaCyber.Net.Filters
{
    ///
    public class FilterRange<T> : FilterEqual<T>
    {
        ///
        public FilterRange(string name, Filter map)
            : base(name, map)
        {
        }

        ///
        public void SetLessThan(T value)
        {
            string lessThanKey = Name + "__lt";
            Map[lessThanKey] = value;
        }

        ///
        public T GetLessThan()
        {
            string lessThanKey = Name + "__lt";
            if (Map.ContainsKey(lessThanKey) && Map[lessThanKey] is T lessThanValue)
            {
                return lessThanValue;
            }
            return default(T)!;
        }

        ///
        public void SetLessThanEqual(T value)
        {
            string lessThanEqualKey = Name + "__lte";
            Map[lessThanEqualKey] = value;
        }

        ///
        public T GetLessThanEqual()
        {
            string lessThanEqualKey = Name + "__lte";
            if (Map.ContainsKey(lessThanEqualKey) && Map[lessThanEqualKey] is T lessThanEqualValue)
            {
                return lessThanEqualValue;
            }
            return default(T)!;
        }

        ///
        public void SetGreaterThan(T value)
        {
            string greaterThanKey = Name + "__gt";
            Map[greaterThanKey] = value;
        }

        ///
        public T GetGreaterThan()
        {
            string greaterThanKey = Name + "__gt";
            if (Map.ContainsKey(greaterThanKey) && Map[greaterThanKey] is T greaterThanValue)
            {
                return greaterThanValue;
            }
            return default(T)!;
        }

        ///
        public void SetGreaterThanEqual(T value)
        {
            string greaterThanEqualKey = Name + "__gte";
            Map[greaterThanEqualKey] = value;
        }

        ///
        public T GetGreaterThanEqual()
        {
            string greaterThanEqualKey = Name + "__gte";
            if (Map.ContainsKey(greaterThanEqualKey) && Map[greaterThanEqualKey] is T greaterThanEqualValue)
            {
                return greaterThanEqualValue;
            }
            return default(T)!;
        }
    }
}
