﻿using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ApiLibrary;
//
//    var analyzeImageResponse = AnalyzeImageResponse.FromJson(jsonString);

namespace ApiLibrary
{
    public partial class AnalyzeImageResponse
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("adult")]
        public Adult Adult { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("requestId")]
        public Guid RequestId { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("faces")]
        public List<Face> Faces { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("imageType")]
        public ImageType ImageType { get; set; }

        [JsonProperty("objects")]
        public List<Object> Objects { get; set; }
    }

    public partial class Adult
    {
        [JsonProperty("isAdultContent")]
        public bool IsAdultContent { get; set; }

        [JsonProperty("isRacyContent")]
        public bool IsRacyContent { get; set; }

        [JsonProperty("adultScore")]
        public double AdultScore { get; set; }

        [JsonProperty("racyScore")]
        public double RacyScore { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public Detail Detail { get; set; }
    }

    public partial class Detail
    {
        [JsonProperty("celebrities")]
        public List<Celebrity> Celebrities { get; set; }

        [JsonProperty("landmarks")]
        public List<Tag> Landmarks { get; set; }
    }

    public partial class Celebrity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class FaceRectangle
    {
        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("dominantColorForeground")]
        public string DominantColorForeground { get; set; }

        [JsonProperty("dominantColorBackground")]
        public string DominantColorBackground { get; set; }

        [JsonProperty("dominantColors")]
        public List<string> DominantColors { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }

        [JsonProperty("isBWImg")]
        public bool IsBwImg { get; set; }
    }

    public partial class Description
    {
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("captions")]
        public List<Caption> Captions { get; set; }
    }

    public partial class Caption
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class Face
    {
        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }

    public partial class ImageType
    {
        [JsonProperty("clipArtType")]
        public long ClipArtType { get; set; }

        [JsonProperty("lineDrawingType")]
        public long LineDrawingType { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }

    public partial class Object
    {
        [JsonProperty("rectangle")]
        public Rectangle Rectangle { get; set; }

        [JsonProperty("object")]
        public string ObjectObject { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class Rectangle
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }
    }

    public partial class AnalyzeImageResponse
    {
        public static AnalyzeImageResponse FromJson(string json) => JsonConvert.DeserializeObject<AnalyzeImageResponse>(json, ApiLibrary.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AnalyzeImageResponse self) => JsonConvert.SerializeObject(self, ApiLibrary.Converter.Settings);
    }

    internal static class Converter
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
