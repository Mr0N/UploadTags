namespace UploadTags.Interface
{
    public interface IWorker
    {
        /// <summary>
        /// Recursive download from DB info and upload tags to creazilla
        /// </summary>
        public void Start();
    }
}
