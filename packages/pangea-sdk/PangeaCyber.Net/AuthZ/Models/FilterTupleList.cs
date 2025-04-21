using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.AuthZ.Models;

///
public sealed class FilterTupleList : Filter
{
    ///
    public FilterMatch<string> ResourceType { get; set; }

    ///
    public FilterMatch<string> ResourceID { get; set; }

    ///
    public FilterMatch<string> SubjectType { get; set; }

    ///
    public FilterMatch<string> SubjectAction { get; set; }

    ///
    public FilterMatch<string> SubjectID { get; set; }

    ///
    public FilterMatch<string> Relation { get; set; }

    ///
    public FilterMatch<DateTimeOffset> ExpiresAt { get; set; }

    ///
    public FilterTupleList()
    {
        ResourceType = new FilterMatch<string>("resource_type", this);
        ResourceID = new FilterMatch<string>("resource_id", this);
        SubjectType = new FilterMatch<string>("subject_type", this);
        SubjectID = new FilterMatch<string>("subject_id", this);
        SubjectAction = new FilterMatch<string>("subject_action", this);
        Relation = new FilterMatch<string>("relation", this);
        ExpiresAt = new FilterMatch<DateTimeOffset>("expires_at", this);
    }
}
