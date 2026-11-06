namespace Common.Models
{
    /// <summary>
    /// Model class representing an uploaded document. Utilized to store the file name and upload date, as that is all we were instructed to do for this assignement
    /// </summary>
    public class UploadedDocument
    {
        /// <summary>
        /// String representing the name of the uploaded file.
        /// </summary>
        public string FileName { get; set; } = string.Empty;
        /// <summary>
        /// Date representing when the file was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; }
    }
}