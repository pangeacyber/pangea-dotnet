using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>PII entity detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class PiiEntityOverride
{
    /// <summary>Whether PII entity detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action for email address detection.</summary>
    public PiiEntityAction? EmailAddress { get; set; }

    /// <summary>Action for NRP detection.</summary>
    public PiiEntityAction? Nrp { get; set; }

    /// <summary>Action for location detection.</summary>
    public PiiEntityAction? Location { get; set; }

    /// <summary>Action for person detection.</summary>
    public PiiEntityAction? Person { get; set; }

    /// <summary>Action for phone number detection.</summary>
    public PiiEntityAction? PhoneNumber { get; set; }

    /// <summary>Action for date/time detection.</summary>
    public PiiEntityAction? DateTime { get; set; }

    /// <summary>Action for IP address detection.</summary>
    public PiiEntityAction? IpAddress { get; set; }

    /// <summary>Action for URL detection.</summary>
    public PiiEntityAction? Url { get; set; }

    /// <summary>Action for money detection.</summary>
    public PiiEntityAction? Money { get; set; }

    /// <summary>Action for credit card detection.</summary>
    public PiiEntityAction? CreditCard { get; set; }

    /// <summary>Action for crypto detection.</summary>
    public PiiEntityAction? Crypto { get; set; }

    /// <summary>Action for IBAN code detection.</summary>
    public PiiEntityAction? IbanCode { get; set; }

    /// <summary>Action for US bank number detection.</summary>
    public PiiEntityAction? UsBankNumber { get; set; }

    /// <summary>Action for NIF detection.</summary>
    public PiiEntityAction? Nif { get; set; }

    /// <summary>Action for AU ABN detection.</summary>
    public PiiEntityAction? AuAbn { get; set; }

    /// <summary>Action for AU ACN detection.</summary>
    public PiiEntityAction? AuAcn { get; set; }

    /// <summary>Action for AU TFN detection.</summary>
    public PiiEntityAction? AuTfn { get; set; }

    /// <summary>Action for medical license detection.</summary>
    public PiiEntityAction? MedicalLicense { get; set; }

    /// <summary>Action for UK NHS detection.</summary>
    public PiiEntityAction? UkNhs { get; set; }

    /// <summary>Action for AU Medicare detection.</summary>
    public PiiEntityAction? AuMedicare { get; set; }

    /// <summary>Action for US driver's license detection.</summary>
    public PiiEntityAction? UsDriversLicense { get; set; }

    /// <summary>Action for US ITIN detection.</summary>
    public PiiEntityAction? UsItin { get; set; }

    /// <summary>Action for US passport detection.</summary>
    public PiiEntityAction? UsPassport { get; set; }

    /// <summary>Action for US SSN detection.</summary>
    public PiiEntityAction? UsSsn { get; set; }
}
