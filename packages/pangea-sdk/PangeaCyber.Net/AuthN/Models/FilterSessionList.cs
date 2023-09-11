namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterSessionList : Filter
    {

        ///
        public string? ActiveTokenId
        {
            get => TryGetValue("active_token_id", out var value) ? (string?)value : null;
            set => this["active_token_id"] = value;
        }

        ///
        public List<string>? ActiveTokenIdContains
        {
            get => TryGetValue("active_token_id__contains", out var value) ? (List<string>?)value : null;
            set => this["active_token_id__contains"] = value;
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
        public string? Email
        {
            get => TryGetValue("email", out var value) ? (string?)value : null;
            set => this["email"] = value;
        }

        ///
        public List<string>? EmailContains
        {
            get => TryGetValue("email__contains", out var value) ? (List<string>?)value : null;
            set => this["email__contains"] = value;
        }

        ///
        public string? Expire
        {
            get => TryGetValue("expire", out var value) ? (string?)value : null;
            set => this["expire"] = value;
        }

        ///
        public string? ExpireGt
        {
            get => TryGetValue("expire__gt", out var value) ? (string?)value : null;
            set => this["expire__gt"] = value;
        }

        ///
        public string? ExpireGte
        {
            get => TryGetValue("expire__gte", out var value) ? (string?)value : null;
            set => this["expire__gte"] = value;
        }

        ///
        public string? ExpireLt
        {
            get => TryGetValue("expire__lt", out var value) ? (string?)value : null;
            set => this["expire__lt"] = value;
        }

        ///
        public string? ExpireLte
        {
            get => TryGetValue("expire__lte", out var value) ? (string?)value : null;
            set => this["expire__lte"] = value;
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
        public string? Identity
        {
            get => TryGetValue("identity", out var value) ? (string?)value : null;
            set => this["identity"] = value;
        }

        ///
        public List<string>? IdentityContains
        {
            get => TryGetValue("identity__contains", out var value) ? (List<string>?)value : null;
            set => this["identity__contains"] = value;
        }

        ///
        public List<string>? Scopes
        {
            get => TryGetValue("scopes", out var value) ? (List<string>?)value : null;
            set => this["scopes"] = value;
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
    }
}
