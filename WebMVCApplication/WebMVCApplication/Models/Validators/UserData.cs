namespace WebMVCApplication.Models.Validators
{
    public class UserData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int? Gender { get; set; }

        public int? Age { get; set; }

        public List<string>? Interests { get; set; }

        public UserDetail? UserDetail { get; set; }
    }

    public class UserDetail
    {
        public string? School { get; set; }
    }
}
