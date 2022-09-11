namespace UploadTags.Models
{
    
        public class UpdateTagsDto
    {
            public int? id { get; set; }
            public DateTime? updated_at { get; set; }
            public int? license_id { get; set; }
            public int? section_id { get; set; }
            public DateTime? created_at { get; set; }
            public string content_type { get; set; }
            public int? content_id { get; set; }
            public int? downloads_count { get; set; }
            public object position { get; set; }
            public int? author_id { get; set; }
            public int? credit_id { get; set; }
            public string nid { get; set; }
            public string translatable_name { get; set; }
            public object wikidata_url { get; set; }
            public int? user_id { get; set; }
            public object discarded_at { get; set; }
            public string status { get; set; }
            public bool? broken { get; set; }
            public string name { get; set; }
            public object description { get; set; }
            public string url { get; set; }
        }

}
