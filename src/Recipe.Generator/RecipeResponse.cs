// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Recipe.Generator;
//
//    var recipeResponse = RecipeResponse.FromJson(jsonString);

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Recipe.Generator
{

    public partial class RecipeResponse
    {
        [JsonProperty("recipes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Recipe> Recipes { get; set; }
    }

    public partial class Recipe
    {
        [JsonProperty("vegetarian", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Vegetarian { get; set; }

        [JsonProperty("vegan", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Vegan { get; set; }

        [JsonProperty("glutenFree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? GlutenFree { get; set; }

        [JsonProperty("dairyFree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DairyFree { get; set; }

        [JsonProperty("veryHealthy", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VeryHealthy { get; set; }

        [JsonProperty("cheap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Cheap { get; set; }

        [JsonProperty("veryPopular", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VeryPopular { get; set; }

        [JsonProperty("sustainable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Sustainable { get; set; }

        [JsonProperty("weightWatcherSmartPoints", NullValueHandling = NullValueHandling.Ignore)]
        public long? WeightWatcherSmartPoints { get; set; }

        [JsonProperty("gaps", NullValueHandling = NullValueHandling.Ignore)]
        public string Gaps { get; set; }

        [JsonProperty("lowFodmap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LowFodmap { get; set; }

        [JsonProperty("ketogenic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ketogenic { get; set; }

        [JsonProperty("whole30", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Whole30 { get; set; }

        [JsonProperty("servings", NullValueHandling = NullValueHandling.Ignore)]
        public long? Servings { get; set; }

        [JsonProperty("sourceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceUrl { get; set; }

        [JsonProperty("spoonacularSourceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SpoonacularSourceUrl { get; set; }

        [JsonProperty("aggregateLikes", NullValueHandling = NullValueHandling.Ignore)]
        public long? AggregateLikes { get; set; }

        [JsonProperty("spoonacularScore", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpoonacularScore { get; set; }

        [JsonProperty("healthScore", NullValueHandling = NullValueHandling.Ignore)]
        public long? HealthScore { get; set; }

        [JsonProperty("creditText", NullValueHandling = NullValueHandling.Ignore)]
        public string CreditText { get; set; }

        [JsonProperty("license", NullValueHandling = NullValueHandling.Ignore)]
        public string License { get; set; }

        [JsonProperty("sourceName", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceName { get; set; }

        [JsonProperty("pricePerServing", NullValueHandling = NullValueHandling.Ignore)]
        public double? PricePerServing { get; set; }

        [JsonProperty("extendedIngredients", NullValueHandling = NullValueHandling.Ignore)]
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("readyInMinutes", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReadyInMinutes { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("imageType", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageType { get; set; }

        [JsonProperty("cuisines", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Cuisines { get; set; }

        [JsonProperty("dishTypes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DishTypes { get; set; }

        [JsonProperty("diets", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Diets { get; set; }

        [JsonProperty("occasions", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Occasions { get; set; }

        [JsonProperty("winePairing", NullValueHandling = NullValueHandling.Ignore)]
        public WinePairing WinePairing { get; set; }

        [JsonProperty("instructions", NullValueHandling = NullValueHandling.Ignore)]
        public string Instructions { get; set; }

        [JsonProperty("analyzedInstructions", NullValueHandling = NullValueHandling.Ignore)]
        public List<AnalyzedInstruction> AnalyzedInstructions { get; set; }

        [JsonProperty("creditsText", NullValueHandling = NullValueHandling.Ignore)]
        public string CreditsText { get; set; }
    }

    public partial class AnalyzedInstruction
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("steps", NullValueHandling = NullValueHandling.Ignore)]
        public List<Step> Steps { get; set; }
    }

    public partial class Step
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("step", NullValueHandling = NullValueHandling.Ignore)]
        public string StepStep { get; set; }

        [JsonProperty("ingredients", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ent> Ingredients { get; set; }

        [JsonProperty("equipment", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ent> Equipment { get; set; }

        [JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
        public Temperature Length { get; set; }
    }

    public partial class Ent
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public Temperature Temperature { get; set; }
    }

    public partial class Temperature
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }
    }

    public partial class ExtendedIngredient
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("aisle", NullValueHandling = NullValueHandling.Ignore)]
        public string Aisle { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("consistency", NullValueHandling = NullValueHandling.Ignore)]
        public Consistency? Consistency { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("originalString", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalString { get; set; }

        [JsonProperty("metaInformation", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MetaInformation { get; set; }
    }

    public partial class WinePairing
    {
        [JsonProperty("pairedWines", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PairedWines { get; set; }

        [JsonProperty("pairingText", NullValueHandling = NullValueHandling.Ignore)]
        public string PairingText { get; set; }

        [JsonProperty("productMatches", NullValueHandling = NullValueHandling.Ignore)]
        public List<ProductMatch> ProductMatches { get; set; }
    }

    public partial class ProductMatch
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("averageRating", NullValueHandling = NullValueHandling.Ignore)]
        public double? AverageRating { get; set; }

        [JsonProperty("ratingCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? RatingCount { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public double? Score { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }
    }

    public enum Consistency { Liquid, Solid };

    public partial class RecipeResponse
    {
        public static RecipeResponse FromJson(string json) => JsonConvert.DeserializeObject<RecipeResponse>(json, Converter.Settings);
    }

    static class ConsistencyExtensions
    {
        public static Consistency? ValueForString(string str)
        {
            switch (str)
            {
                case "liquid": return Consistency.Liquid;
                case "solid": return Consistency.Solid;
                default: return null;
            }
        }

        public static Consistency ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Consistency value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Consistency.Liquid: serializer.Serialize(writer, "liquid"); break;
                case Consistency.Solid: serializer.Serialize(writer, "solid"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this RecipeResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Consistency) || t == typeof(Consistency?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Consistency))
                return ConsistencyExtensions.ReadJson(reader, serializer);
            if (t == typeof(Consistency?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ConsistencyExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Consistency))
            {
                ((Consistency)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
