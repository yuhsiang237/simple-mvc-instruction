namespace WebMVCApplication.Models.EFCoreModels
{
    public class TodoEFModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public int? UserId { get; set; }
        public int? Priority { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}