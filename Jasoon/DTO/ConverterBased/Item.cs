using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Jasoon.DTO.ConverterBased;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
[JsonConverter(typeof(ItemCustomConverter))]
public record Item
{
    public Guid Id { get; init; }

    [JsonConverter(typeof(StringEnumConverter))]
    public virtual ItemType Discrimintator => ItemType.Base;
}

public record ItemWithPreviewDetails : Item
{
    public string Name { get; init; } = string.Empty;

    [JsonConverter(typeof(StringEnumConverter))]
    public override ItemType Discrimintator => ItemType.Preview;
}

public record ItemWithFullDetails : ItemWithPreviewDetails
{
    public string FullName { get; init; } = string.Empty;


    [JsonConverter(typeof(StringEnumConverter))]
    public override ItemType Discrimintator => ItemType.Full;
}

public enum ItemType
{
    Base = 0,
    Preview = 1,
    Full = 2,
}

public class ItemCustomConverter : JsonConverter<Item>
{ 
    public override Item? ReadJson(JsonReader reader, Type objectType, Item? existingValue, bool hasExistingValue, JsonSerializer serializer)
    { 
        var jsonObject = JObject.Load(reader);

        var discriminatorRaw = jsonObject
            .GetValue("discrimintator", StringComparison.InvariantCultureIgnoreCase)?
            .ToString();

        if (Enum.TryParse<ItemType>(discriminatorRaw, out var discriminator))
        {
            serializer.ContractResolver =  new CleanupResolver();

            return discriminator switch
            {
                ItemType.Base => jsonObject.ToObject<Item>(serializer),
                ItemType.Preview => jsonObject.ToObject<ItemWithPreviewDetails>(serializer),
                ItemType.Full => jsonObject.ToObject<ItemWithFullDetails>(serializer),
                _ => throw new NotImplementedException(),
            }; 
        }

        return null;
    }

    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, Item? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    internal sealed class CleanupResolver : DefaultContractResolver
    {
        protected override JsonConverter? ResolveContractConverter(Type objectType)
        {
            if (objectType == typeof(Item)) return null;
            if (objectType == typeof(ItemWithPreviewDetails)) return null;
            if (objectType == typeof(ItemWithFullDetails)) return null;

            return base.ResolveContractConverter(objectType);
        }
    }

}


