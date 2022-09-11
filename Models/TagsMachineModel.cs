namespace UploadTags.Models
{

    public class TagMachineModel
    {
        public object Filename { get; set; }
        public object Probability { get; set; }
        public object FoundTags { get; set; }
        public error Error { get; set; }
    }

    public class error
    {
        public string Status { get; set; }
        public string Details { get; set; }
    }

}
