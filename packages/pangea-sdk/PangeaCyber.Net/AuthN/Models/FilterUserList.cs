namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterUserList : Filter
    {

        ///
        public string? AcceptedEulaId
        {
            get => TryGetValue("accepted_eula_id", out var value) ? (string?)value : null;
            set => this["accepted_eula_id"] = value;
        }

        ///
        public List<string>? AcceptedEulaIdContains
        {
            get => TryGetValue("accepted_eula_id__contains", out var value) ? (List<string>?)value : null;
            set => this["accepted_eula_id__contains"] = value;
        }

        ///
        public List<string>? AcceptedEulaIdIn
        {
            get => TryGetValue("accepted_eula_id__in", out var value) ? (List<string>?)value : null;
            set => this["accepted_eula_id__in"] = value;
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
        public bool? Disabled
        {
            get => TryGetValue("disabled", out var value) ? (bool?)value : null;
            set => this["disabled"] = value;
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
        public string? LastLoginAt
        {
            get => TryGetValue("last_login_at", out var value) ? (string?)value : null;
            set => this["last_login_at"] = value;
        }

        ///
        public string? LastLoginAtGt
        {
            get => TryGetValue("last_login_at__gt", out var value) ? (string?)value : null;
            set => this["last_login_at__gt"] = value;
        }

        ///
        public string? LastLoginAtGte
        {
            get => TryGetValue("last_login_at__gte", out var value) ? (string?)value : null;
            set => this["last_login_at__gte"] = value;
        }

        ///
        public string? LastLoginAtLt
        {
            get => TryGetValue("last_login_at__lt", out var value) ? (string?)value : null;
            set => this["last_login_at__lt"] = value;
        }

        ///
        public string? LastLoginAtLte
        {
            get => TryGetValue("last_login_at__lte", out var value) ? (string?)value : null;
            set => this["last_login_at__lte"] = value;
        }

        ///
        public string? LastLoginIp
        {
            get => TryGetValue("last_login_ip", out var value) ? (string?)value : null;
            set => this["last_login_ip"] = value;
        }

        ///
        public List<string>? LastLoginIpContains
        {
            get => TryGetValue("last_login_ip__contains", out var value) ? (List<string>?)value : null;
            set => this["last_login_ip__contains"] = value;
        }

        ///
        public string? LastLoginCity
        {
            get => TryGetValue("last_login_city", out var value) ? (string?)value : null;
            set => this["last_login_city"] = value;
        }

        ///
        public List<string>? LastLoginCityContains
        {
            get => TryGetValue("last_login_city__contains", out var value) ? (List<string>?)value : null;
            set => this["last_login_city__contains"] = value;
        }

        ///
        public string? LastLoginCountry
        {
            get => TryGetValue("last_login_country", out var value) ? (string?)value : null;
            set => this["last_login_country"] = value;
        }

        ///
        public List<string>? LastLoginCountryContains
        {
            get => TryGetValue("last_login_country__contains", out var value) ? (List<string>?)value : null;
            set => this["last_login_country__contains"] = value;
        }

        ///
        public int? LoginCount
        {
            get => TryGetValue("login_count", out var value) ? (int?)value : null;
            set => this["login_count"] = value;
        }

        ///
        public int? LoginCountGt
        {
            get => TryGetValue("login_count__gt", out var value) ? (int?)value : null;
            set => this["login_count__gt"] = value;
        }

        ///
        public int? LoginCountGte
        {
            get => TryGetValue("login_count__gte", out var value) ? (int?)value : null;
            set => this["login_count__gte"] = value;
        }

        ///
        public int? LoginCountLt
        {
            get => TryGetValue("login_count__lt", out var value) ? (int?)value : null;
            set => this["login_count__lt"] = value;
        }

        ///
        public int? LoginCountLte
        {
            get => TryGetValue("login_count__lte", out var value) ? (int?)value : null;
            set => this["login_count__lte"] = value;
        }

        ///
        public bool? RequireMfa
        {
            get => TryGetValue("require_mfa", out var value) ? (bool?)value : null;
            set => this["require_mfa"] = value;
        }

        ///
        public List<string>? Scopes
        {
            get => TryGetValue("scopes", out var value) ? (List<string>?)value : null;
            set => this["scopes"] = value;
        }

        ///
        public bool? Verified
        {
            get => TryGetValue("verified", out var value) ? (bool?)value : null;
            set => this["verified"] = value;
        }
    }
}
