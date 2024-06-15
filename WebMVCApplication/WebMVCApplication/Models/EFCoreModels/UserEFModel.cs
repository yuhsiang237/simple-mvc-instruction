namespace WebMVCApplication.Models.EFCoreModels
{
    public class UserEFModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}