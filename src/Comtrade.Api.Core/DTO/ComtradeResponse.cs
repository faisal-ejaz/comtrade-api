using System;

namespace Comtrade.Api.Core.DTO
{
    /// <summary>
    /// ComTrade response data transfer object
    /// </summary>
    public class ComtradeResponse
    {
        public Validation Validation { get; set; }
        public Dataset[] Dataset { get; set; }
    }

    /// <summary>
    /// Validation object model for ComTrade data
    /// </summary>
    public class Validation
    {
        public Status Status { get; set; }

        public object Message { get; set; }

        public Count Count { get; set; }

        public Count DatasetTimer { get; set; }
    }

    /// <summary>
    /// Count object model for ComTrade data
    /// </summary>
    public class Count
    {
        public long? Value { get; set; }

        public DateTimeOffset Started { get; set; }

        public DateTimeOffset Finished { get; set; }

        public double DurationSeconds { get; set; }
    }

    /// <summary>
    /// Status object model for ComTrade data
    /// </summary>
    public class Status
    {
        public string Name { get; set; }

        public long Value { get; set; }

        public long Category { get; set; }

        public string Description { get; set; }

        public string HelpUrl { get; set; }
    }

    /// <summary>
    /// Dataset object model for ComTrade data
    /// </summary>
    public class Dataset
    {
        public string PfCode { get; set; }

        public long Yr { get; set; }

        public long Period { get; set; }

        public string PeriodDesc { get; set; }

        public long AggrLevel { get; set; }

        public long IsLeaf { get; set; }

        public long RgCode { get; set; }

        public string RgDesc { get; set; }

        public long RtCode { get; set; }

        public string RtTitle { get; set; }

        public string Rt3Iso { get; set; }

        public long PtCode { get; set; }

        public string PtTitle { get; set; }

        public string Pt3Iso { get; set; }

        public object PtCode2 { get; set; }

        public string PtTitle2 { get; set; }

        public string Pt3Iso2 { get; set; }

        public string CstCode { get; set; }

        public string CstDesc { get; set; }

        public string MotCode { get; set; }

        public string MotDesc { get; set; }

        public string CmdCode { get; set; }

        public string CmdDescE { get; set; }

        public long QtCode { get; set; }

        public string QtDesc { get; set; }

        public object QtAltCode { get; set; }

        public string QtAltDesc { get; set; }

        public long? TradeQuantity { get; set; }

        public object AltQuantity { get; set; }

        public long? NetWeight { get; set; }

        public object GrossWeight { get; set; }

        public long TradeValue { get; set; }

        public object CifValue { get; set; }

        public object FobValue { get; set; }

        public long EstCode { get; set; }
    }
}
