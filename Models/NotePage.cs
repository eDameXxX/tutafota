using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fotooo.Models
{
    public class NotePage
    {
        public partial class Start : NotePage
        {
            [JsonProperty("@odata.context")]
            public string OdataContext { get; set; }

            [JsonProperty("@odata.nextLink")]
            public string OdataNextLink { get; set; }

            [JsonProperty("value")]
            public Value[] Value { get; set; }
        }

        public partial class Value : NotePage
        {
            [JsonProperty("contentUrl")]
            public string ContentUrl { get; set; }

            [JsonProperty("createdByAppId")]
            public string CreatedByAppId { get; set; }

            [JsonProperty("createdDateTime")]
            public string CreatedDateTime { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("lastModifiedDateTime")]
            public string LastModifiedDateTime { get; set; }

            [JsonProperty("links")]
            public Links Links { get; set; }

            [JsonProperty("parentSection")]
            public ParentSection ParentSection { get; set; }

            [JsonProperty("parentSection@odata.context")]
            public string ParentSectionOdataContext { get; set; }

            [JsonProperty("self")]
            public string Self { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }
        }

        public partial class ParentSection : NotePage
        {
            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("self")]
            public string Self { get; set; }
        }

        public partial class Links : NotePage
        {
            [JsonProperty("oneNoteClientUrl")]
            public OneNoteUrl OneNoteClientUrl { get; set; }

            [JsonProperty("oneNoteWebUrl")]
            public OneNoteUrl OneNoteWebUrl { get; set; }
        }

        public partial class OneNoteUrl : NotePage
        {
            [JsonProperty("href")]
            public string Href { get; set; }
        }

        public partial class Start : NotePage
        {
            public static Start FromJson(string json) => JsonConvert.DeserializeObject<Start>(json, Converter.Settings);
        }

       

        public class Converter : NotePage
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
        
    }


}
