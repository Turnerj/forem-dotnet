using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Forem.Api.Models.Listing
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ListingCategory
    {
        [EnumMember(Value = "cfp")]
        Cfp,
        [EnumMember(Value = "forhire")]
        ForHire,
        [EnumMember(Value = "collabs")]
        Collabs,
        [EnumMember(Value = "education")]
        Education,
        [EnumMember(Value = "jobs")]
        Jobs,
        [EnumMember(Value = "mentors")]
        Mentors,
        [EnumMember(Value = "products")]
        Products,
        [EnumMember(Value = "mentees")]
        Mentees,
        [EnumMember(Value = "forsale")]
        ForSale,
        [EnumMember(Value = "events")]
        Events,
        [EnumMember(Value = "misc")]
        Misc,
    }
}
