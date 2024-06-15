namespace WebMVCApplication.Models.EFCoreModels
{
    public class TodoWithUserEFModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public int? UserId { get; set; }

        public string? UserName { get; set; }
    }
}