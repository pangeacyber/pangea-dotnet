namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterUserInviteList : Filter
    {

        ///
        public string? Callback
        {
            get => TryGetValue("callback", out var value) ? (string?)value : null;
            set => this["callback"] = value;
        }

        ///
        public List<string>? CallbackContains
        {
            get => TryGetValue("callback__contains", out var value) ? (List<string>?)value : null;
            set => this["callback__contains"] = value;
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
        public string? InviteOrg
        {
            get => TryGetValue("invite_org", out var value) ? (string?)value : null;
            set => this["invite_org"] = value;
        }

        ///
        public List<string>? InviteOrgContains
        {
            get => TryGetValue("invite_org__contains", out var value) ? (List<string>?)value : null;
            set => this["invite_org__contains"] = value;
        }

        ///
        public string? Inviter
        {
            get => TryGetValue("inviter", out var value) ? (string?)value : null;
            set => this["inviter"] = value;
        }

        ///
        public List<string>? InviterContains
        {
            get => TryGetValue("inviter__contains", out var value) ? (List<string>?)value : null;
            set => this["inviter__contains"] = value;
        }

        ///
        public bool? IsSignup
        {
            get => TryGetValue("is_signup", out var value) ? (bool?)value : null;
            set => this["is_signup"] = value;
        }

        ///
        public bool? RequireMfa
        {
            get => TryGetValue("require_mfa", out var value) ? (bool?)value : null;
            set => this["require_mfa"] = value;
        }

        ///
        public string? State
        {
            get => TryGetValue("state", out var value) ? (string?)value : null;
            set => this["state"] = value;
        }

        ///
        public List<string>? StateContains
        {
            get => TryGetValue("state__contains", out var value) ? (List<string>?)value : null;
            set => this["state__contains"] = value;
        }
    }
}
