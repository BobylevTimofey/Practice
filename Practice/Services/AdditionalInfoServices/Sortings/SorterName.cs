using System.Text.Json.Serialization;
namespace Practice.Services.AdditionalInfoServices.Sortings
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SorterName
    {
        QuickSort,
        TreeSort
    }
}
