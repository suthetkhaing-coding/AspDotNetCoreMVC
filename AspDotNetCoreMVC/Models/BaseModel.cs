namespace AspDotNetCoreMVC.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
