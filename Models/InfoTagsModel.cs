namespace UploadTags.Models
{

    public class InfoTagsModel
    {
        public int? id { get; set; }
        public object license_id { get; set; }
        public int? section_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string content_type { get; set; }
        public int? content_id { get; set; }
        public int? downloads_count { get; set; }
        public int? position { get; set; }
        public int? author_id { get; set; }
        public object credit_id { get; set; }
        public object nid { get; set; }
        public string translatable_name { get; set; }
        public object wikidata_url { get; set; }
        public int? user_id { get; set; }
        public object discarded_at { get; set; }
        public string status { get; set; }
        public bool? broken { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Content_Media content_media { get; set; }
        public bool? discarded { get; set; }
        public object content { get; set; }
        public Tagging[] taggings { get; set; }
        public Tag[] tags { get; set; }
        public Author author { get; set; }
        public string site_url { get; set; }
        public object liked { get; set; }
    }

    public class Content_Media
    {
        public Cover cover { get; set; }
        public Graphics graphics { get; set; }
    }

    public class Cover
    {
        public string url { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public string mime_type { get; set; }
        public int? size { get; set; }
    }

    public class Graphics
    {
        public string url { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public string mime_type { get; set; }
        public int? size { get; set; }
    }

    public class Author
    {
        public int? id { get; set; }
        public string name { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string to_param { get; set; }
    }

    public class Tagging
    {
        public int? node_id { get; set; }
        public int? tag_id { get; set; }
        public int? id { get; set; }
        public int? score { get; set; }
    }

    public class Tag
    {
        public int? id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public object custom_cover_data { get; set; }
        public int? position { get; set; }
        public string wikidata_url { get; set; }
        public object synonyms { get; set; }
        public bool? lexception { get; set; }
        public object kit { get; set; }
        public Counters counters { get; set; }
        public object origin_id { get; set; }
        public string tsv { get; set; }
        public string name { get; set; }
        public object title { get; set; }
        public object description { get; set; }
        public string to_param { get; set; }
    }

    public class Counters
    {
        public int? nodes { get; set; }
        public int? photos { get; set; }
        public int? clipart { get; set; }
        public int? vectors { get; set; }
        public int? fragments { get; set; }
        public int? silhouettes { get; set; }
        public int? illustrations { get; set; }
        public int? three_d_models { get; set; }
        public int? fonts { get; set; }
        public int? icons { get; set; }
    }

}
