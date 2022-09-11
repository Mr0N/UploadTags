namespace UploadTags.Models
{


    public class NodeUpdate
    {
        public Node node { get; set; }
    }

    public class Node
    {
        public IEnumerable<int> tag_ids { get; set; }
    }

}
