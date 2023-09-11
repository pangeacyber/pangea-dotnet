namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterAgreementList : Filter
    {
        ///
        public bool? Active
        {
            get => TryGetValue("active", out var value) ? (bool?)value : null;
            set => this["active"] = value;
        }

        ///
        public string? CreatedAt
        {
            get => TryGetValue("created_at", out var value) ? (string?)value : null;
            set => this["created_at"] = value;
        }

        ///
        public string? CreatedAtGt
        {
            get => TryGetValue("created_at__gt", out var value) ? (string?)value : null;
            set => this["created_at__gt"] = value;
        }

        ///
        public string? CreatedAtGte
        {
            get => TryGetValue("created_at__gte", out var value) ? (string?)value : null;
            set => this["created_at__gte"] = value;
        }

        ///
        public string? CreatedAtLt
        {
            get => TryGetValue("created_at__lt", out var value) ? (string?)value : null;
            set => this["created_at__lt"] = value;
        }

        ///
        public string? CreatedAtLte
        {
            get => TryGetValue("created_at__lte", out var value) ? (string?)value : null;
            set => this["created_at__lte"] = value;
        }

        ///
        public string? PublishedAt
        {
            get => TryGetValue("published_at", out var value) ? (string?)value : null;
            set => this["published_at"] = value;
        }

        ///
        public string? PublishedAtGt
        {
            get => TryGetValue("published_at__gt", out var value) ? (string?)value : null;
            set => this["published_at__gt"] = value;
        }

        ///
        public string? PublishedAtGte
        {
            get => TryGetValue("published_at__gte", out var value) ? (string?)value : null;
            set => this["published_at__gte"] = value;
        }

        ///
        public string? PublishedAtLt
        {
            get => TryGetValue("published_at__lt", out var value) ? (string?)value : null;
            set => this["published_at__lt"] = value;
        }

        ///
        public string? PublishedAtLte
        {
            get => TryGetValue("published_at__lte", out var value) ? (string?)value : null;
            set => this["published_at__lte"] = value;
        }

        ///
        public string? Type
        {
            get => TryGetValue("type", out var value) ? (string?)value : null;
            set => this["type"] = value;
        }

        ///
        public List<string>? TypeContains
        {
            get => TryGetValue("type__contains", out var value) ? (List<string>?)value : null;
            set => this["type__contains"] = value;
        }

        ///
        public List<string>? TypeIn
        {
            get => TryGetValue("type__in", out var value) ? (List<string>?)value : null;
            set => this["type__in"] = value;
        }

        ///
        public string? Id
        {
            get => TryGetValue("id", out var value) ? (string?)value : null;
            set => this["id"] = value;
        }

        ///
        public List<string>? IdContains
        {
            get => TryGetValue("id__contains", out var value) ? (List<string>?)value : null;
            set => this["id__contains"] = value;
        }

        ///
        public List<string>? IdIn
        {
            get => TryGetValue("id__in", out var value) ? (List<string>?)value : null;
            set => this["id__in"] = value;
        }

        ///
        public string? Name
        {
            get => TryGetValue("name", out var value) ? (string?)value : null;
            set => this["name"] = value;
        }

        ///
        public List<string>? NameContains
        {
            get => TryGetValue("name__contains", out var value) ? (List<string>?)value : null;
            set => this["name__contains"] = value;
        }

        ///
        public List<string>? NameIn
        {
            get => TryGetValue("name__in", out var value) ? (List<string>?)value : null;
            set => this["name__in"] = value;
        }

        ///
        public string? Text
        {
            get => TryGetValue("text", out var value) ? (string?)value : null;
            set => this["text"] = value;
        }

        ///
        public List<string>? TextContains
        {
            get => TryGetValue("text__contains", out var value) ? (List<string>?)value : null;
            set => this["text__contains"] = value;
        }

        ///
        public List<string>? TextIn
        {
            get => TryGetValue("text__in", out var value) ? (List<string>?)value : null;
            set => this["text__in"] = value;
        }
    }
}
