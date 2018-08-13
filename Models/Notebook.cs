using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fotooo.Models
{
    public partial class Notebook
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public Value[] Value { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("createdBy")]
        public EdBy CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public string CreatedDateTime { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("isShared")]
        public bool IsShared { get; set; }

        [JsonProperty("lastModifiedBy")]
        public EdBy LastModifiedBy { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public string LastModifiedDateTime { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("sectionGroupsUrl")]
        public string SectionGroupsUrl { get; set; }

        [JsonProperty("sectionsUrl")]
        public string SectionsUrl { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("userRole")]
        public string UserRole { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("oneNoteClientUrl")]
        public OneNoteUrl OneNoteClientUrl { get; set; }

        [JsonProperty("oneNoteWebUrl")]
        public OneNoteUrl OneNoteWebUrl { get; set; }
    }

    public partial class OneNoteUrl
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class EdBy
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }

    public partial class User
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Notebook
    {
        public static Notebook FromJson(string json) => JsonConvert.DeserializeObject<Notebook>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Notebook self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
