using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.AuthZ.Models
{
    ///
    public class FilterTupleList : Filter
    {
        ///
        public FilterMatch<string> ResourceNamespace { get; set; }

        ///
        public FilterMatch<string> ResourceID { get; set; }

        ///
        public FilterMatch<string> SubjectNamespace { get; set; }

        ///
        public FilterMatch<string> SubjectAction { get; set; }

        ///
        public FilterMatch<string> SubjectID { get; set; }

        ///
        public FilterMatch<string> Relation { get; set; }

        ///
        public FilterTupleList()
        {
            ResourceNamespace = new FilterMatch<string>("resource_namespace", this);
            ResourceID = new FilterMatch<string>("resource_id", this);
            SubjectNamespace = new FilterMatch<string>("subject_namespace", this);
            SubjectID = new FilterMatch<string>("subject_id", this);
            SubjectAction = new FilterMatch<string>("subject_action", this);
            Relation = new FilterMatch<string>("relation", this);
        }
    }
}
