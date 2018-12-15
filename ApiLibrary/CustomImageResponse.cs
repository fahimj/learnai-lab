namespace ApiLibrary
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CustomImageResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("project")]
        public Guid Project { get; set; }

        [JsonProperty("iteration")]
        public Guid Iteration { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("predictions")]
        public List<Prediction> Predictions { get; set; }
    }

    public partial class Prediction
    {
        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("tagId")]
        public Guid TagId { get; set; }

        [JsonProperty("tagName")]
        public string TagName { get; set; }
    }

    public partial class CustomImageResponse
    {
        public static CustomImageResponse FromJson(string json) => JsonConvert.DeserializeObject<CustomImageResponse>(json, ApiLibrary.Converter.Settings);
    }

    public static class SerializeCustomImageResponse
    {
        public static string ToJson(this CustomImageResponse self) => JsonConvert.SerializeObject(self, ApiLibrary.Converter.Settings);
    }

    internal static class ConverterCustomImageResponse
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
