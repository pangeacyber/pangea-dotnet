namespace PangeaCyber.Net.AIGuard.Models
{
    /// <summary>Detector action</summary>
    public enum DetectorAction
    {
        /// <summary>Detected</summary>
        Detected,

        /// <summary>Redacted</summary>
        Redacted,

        /// <summary>Defanged</summary>
        Defanged,

        /// <summary>Reported</summary>
        Reported,

        /// <summary>Blocked</summary>
        Blocked
    }
}
