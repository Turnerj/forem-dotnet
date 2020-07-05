using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Forem.Api.Models.Listing
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ListingAction
    {
        [EnumMember(Value = "create")]
        Create,
        [EnumMember(Value = "draft")]
        Draft,
        [EnumMember(Value = "bump")]
        Bump,
        [EnumMember(Value = "publish")]
        Publish,
        [EnumMember(Value = "unpublish")]
        Unpublish,
        [EnumMember(Value = "update")]
        Update,
    }
}
