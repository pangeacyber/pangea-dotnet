using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents the file format.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileFormat
    {
        ///
        [EnumMember(Value = "3G2")]
        F3G2,

        ///
        [EnumMember(Value = "3GP")]
        F3GP,

        ///
        [EnumMember(Value = "3MF")]
        F3MF,

        ///
        [EnumMember(Value = "7Z")]
        F7Z,

        ///
        [EnumMember(Value = "A")]
        A,

        ///
        [EnumMember(Value = "AAC")]
        AAC,

        ///
        [EnumMember(Value = "ACCDB")]
        ACCDB,

        ///
        [EnumMember(Value = "AIFF")]
        AIFF,

        ///
        [EnumMember(Value = "AMF")]
        AMF,

        ///
        [EnumMember(Value = "AMR")]
        AMR,

        ///
        [EnumMember(Value = "APE")]
        APE,

        ///
        [EnumMember(Value = "ASF")]
        ASF,

        ///
        [EnumMember(Value = "ATOM")]
        ATOM,

        ///
        [EnumMember(Value = "AU")]
        AU,

        ///
        [EnumMember(Value = "AVI")]
        AVI,

        ///
        [EnumMember(Value = "AVIF")]
        AVIF,

        ///
        [EnumMember(Value = "BIN")]
        BIN,

        ///
        [EnumMember(Value = "BMP")]
        BMP,

        ///
        [EnumMember(Value = "BPG")]
        BPG,

        ///
        [EnumMember(Value = "BZ2")]
        BZ2,

        ///
        [EnumMember(Value = "CAB")]
        CAB,

        ///
        [EnumMember(Value = "CLASS")]
        CLASS,

        ///
        [EnumMember(Value = "CPIO")]
        CPIO,

        ///
        [EnumMember(Value = "CRX")]
        CRX,

        ///
        [EnumMember(Value = "CSV")]
        CSV,

        ///
        [EnumMember(Value = "DAE")]
        DAE,

        ///
        [EnumMember(Value = "DBF")]
        DBF,

        ///
        [EnumMember(Value = "DCM")]
        DCM,

        ///
        [EnumMember(Value = "DEB")]
        DEB,

        ///
        [EnumMember(Value = "DJVU")]
        DJVU,

        ///
        [EnumMember(Value = "DLL")]
        DLL,

        ///
        [EnumMember(Value = "DOC")]
        DOC,

        ///
        [EnumMember(Value = "DOCX")]
        DOCX,

        ///
        [EnumMember(Value = "DWG")]
        DWG,

        ///
        [EnumMember(Value = "EOT")]
        EOT,

        ///
        [EnumMember(Value = "EPUB")]
        EPUB,

        ///
        [EnumMember(Value = "EXE")]
        EXE,

        ///
        [EnumMember(Value = "FDF")]
        FDF,

        ///
        [EnumMember(Value = "FITS")]
        FITS,

        ///
        [EnumMember(Value = "FLAC")]
        FLAC,

        ///
        [EnumMember(Value = "FLV")]
        FLV,

        ///
        [EnumMember(Value = "GBR")]
        GBR,

        ///
        [EnumMember(Value = "GEOJSON")]
        GEOJSON,

        ///
        [EnumMember(Value = "GIF")]
        GIF,

        ///
        [EnumMember(Value = "GLB")]
        GLB,

        ///
        [EnumMember(Value = "GML")]
        GML,

        ///
        [EnumMember(Value = "GPX")]
        GPX,

        ///
        [EnumMember(Value = "GZ")]
        GZ,

        ///
        [EnumMember(Value = "HAR")]
        HAR,

        ///
        [EnumMember(Value = "HDR")]
        HDR,

        ///
        [EnumMember(Value = "HEIC")]
        HEIC,

        ///
        [EnumMember(Value = "HEIF")]
        HEIF,

        ///
        [EnumMember(Value = "HTML")]
        HTML,

        ///
        [EnumMember(Value = "ICNS")]
        ICNS,

        ///
        [EnumMember(Value = "ICO")]
        ICO,

        ///
        [EnumMember(Value = "ICS")]
        ICS,

        ///
        [EnumMember(Value = "ISO")]
        ISO,

        ///
        [EnumMember(Value = "JAR")]
        JAR,

        ///
        [EnumMember(Value = "JP2")]
        JP2,

        ///
        [EnumMember(Value = "JPF")]
        JPF,

        ///
        [EnumMember(Value = "JPG")]
        JPG,

        ///
        [EnumMember(Value = "JPM")]
        JPM,

        ///
        [EnumMember(Value = "JS")]
        JS,

        ///
        [EnumMember(Value = "JSON")]
        JSON,

        ///
        [EnumMember(Value = "JXL")]
        JXL,

        ///
        [EnumMember(Value = "JXR")]
        JXR,

        ///
        [EnumMember(Value = "KML")]
        KML,

        ///
        [EnumMember(Value = "LIT")]
        LIT,

        ///
        [EnumMember(Value = "LNK")]
        LNK,

        ///
        [EnumMember(Value = "LUA")]
        LUA,

        ///
        [EnumMember(Value = "LZ")]
        LZ,

        ///
        [EnumMember(Value = "M3U")]
        M3U,

        ///
        [EnumMember(Value = "M4A")]
        M4A,

        ///
        [EnumMember(Value = "MACHO")]
        MACHO,

        ///
        [EnumMember(Value = "MDB")]
        MDB,

        ///
        [EnumMember(Value = "MIDI")]
        MIDI,

        ///
        [EnumMember(Value = "MKV")]
        MKV,

        ///
        [EnumMember(Value = "MOBI")]
        MOBI,

        ///
        [EnumMember(Value = "MOV")]
        MOV,

        ///
        [EnumMember(Value = "MP3")]
        MP3,

        ///
        [EnumMember(Value = "MP4")]
        MP4,

        ///
        [EnumMember(Value = "MPC")]
        MPC,

        ///
        [EnumMember(Value = "MPEG")]
        MPEG,

        ///
        [EnumMember(Value = "MQV")]
        MQV,

        ///
        [EnumMember(Value = "MRC")]
        MRC,

        ///
        [EnumMember(Value = "MSG")]
        MSG,

        ///
        [EnumMember(Value = "MSI")]
        MSI,

        ///
        [EnumMember(Value = "NDJSON")]
        NDJSON,

        ///
        [EnumMember(Value = "NES")]
        NES,

        ///
        [EnumMember(Value = "ODC")]
        ODC,

        ///
        [EnumMember(Value = "ODF")]
        ODF,

        ///
        [EnumMember(Value = "ODG")]
        ODG,

        ///
        [EnumMember(Value = "ODP")]
        ODP,

        ///
        [EnumMember(Value = "ODS")]
        ODS,

        ///
        [EnumMember(Value = "ODT")]
        ODT,

        ///
        [EnumMember(Value = "OGA")]
        OGA,

        ///
        [EnumMember(Value = "OGV")]
        OGV,

        ///
        [EnumMember(Value = "OTF")]
        OTF,

        ///
        [EnumMember(Value = "OTG")]
        OTG,

        ///
        [EnumMember(Value = "OTP")]
        OTP,

        ///
        [EnumMember(Value = "OTS")]
        OTS,

        ///
        [EnumMember(Value = "OTT")]
        OTT,

        ///
        [EnumMember(Value = "OWL")]
        OWL,

        ///
        [EnumMember(Value = "P7S")]
        P7S,

        ///
        [EnumMember(Value = "PAT")]
        PAT,

        ///
        [EnumMember(Value = "PDF")]
        PDF,

        ///
        [EnumMember(Value = "PHP")]
        PHP,

        ///
        [EnumMember(Value = "PL")]
        PL,

        ///
        [EnumMember(Value = "PNG")]
        PNG,

        ///
        [EnumMember(Value = "PPT")]
        PPT,

        ///
        [EnumMember(Value = "PPTX")]
        PPTX,

        ///
        [EnumMember(Value = "PS")]
        PS,

        ///
        [EnumMember(Value = "PSD")]
        PSD,

        ///
        [EnumMember(Value = "PUB")]
        PUB,

        ///
        [EnumMember(Value = "PY")]
        PY,

        ///
        [EnumMember(Value = "QCP")]
        QCP,

        ///
        [EnumMember(Value = "RAR")]
        RAR,

        ///
        [EnumMember(Value = "RMVB")]
        RMVB,

        ///
        [EnumMember(Value = "RPM")]
        RPM,

        ///
        [EnumMember(Value = "RSS")]
        RSS,

        ///
        [EnumMember(Value = "RTF")]
        RTF,

        ///
        [EnumMember(Value = "SHP")]
        SHP,

        ///
        [EnumMember(Value = "SHX")]
        SHX,

        ///
        [EnumMember(Value = "SO")]
        SO,

        ///
        [EnumMember(Value = "SQLITE")]
        SQLITE,

        ///
        [EnumMember(Value = "SRT")]
        SRT,

        ///
        [EnumMember(Value = "SVG")]
        SVG,

        ///
        [EnumMember(Value = "SWF")]
        SWF,

        ///
        [EnumMember(Value = "SXC")]
        SXC,

        ///
        [EnumMember(Value = "TAR")]
        TAR,

        ///
        [EnumMember(Value = "TCL")]
        TCL,

        ///
        [EnumMember(Value = "TCX")]
        TCX,

        ///
        [EnumMember(Value = "TIFF")]
        TIFF,

        ///
        [EnumMember(Value = "TORRENT")]
        TORRENT,

        ///
        [EnumMember(Value = "TSV")]
        TSV,

        ///
        [EnumMember(Value = "TTC")]
        TTC,

        ///
        [EnumMember(Value = "TTF")]
        TTF,

        ///
        [EnumMember(Value = "TXT")]
        TXT,

        ///
        [EnumMember(Value = "VCF")]
        VCF,

        ///
        [EnumMember(Value = "VOC")]
        VOC,

        ///
        [EnumMember(Value = "VTT")]
        VTT,

        ///
        [EnumMember(Value = "WARC")]
        WARC,

        ///
        [EnumMember(Value = "WASM")]
        WASM,

        ///
        [EnumMember(Value = "WAV")]
        WAV,

        ///
        [EnumMember(Value = "WEBM")]
        WEBM,

        ///
        [EnumMember(Value = "WEBP")]
        WEBP,

        ///
        [EnumMember(Value = "WOFF")]
        WOFF,

        ///
        [EnumMember(Value = "WOFF2")]
        WOFF2,

        ///
        [EnumMember(Value = "X3D")]
        X3D,

        ///
        [EnumMember(Value = "XAR")]
        XAR,

        ///
        [EnumMember(Value = "XCF")]
        XCF,

        ///
        [EnumMember(Value = "XFDF")]
        XFDF,

        ///
        [EnumMember(Value = "XLF")]
        XLF,

        ///
        [EnumMember(Value = "XLS")]
        XLS,

        ///
        [EnumMember(Value = "XLSX")]
        XLSX,

        ///
        [EnumMember(Value = "XML")]
        XML,

        ///
        [EnumMember(Value = "XPM")]
        XPM,

        ///
        [EnumMember(Value = "XZ")]
        XZ,

        ///
        [EnumMember(Value = "ZIP")]
        ZIP,

        ///
        [EnumMember(Value = "ZST")]
        ZST
    }
}
