namespace CRUDAPI.DAL.Entity.DTO
{
    public class JoinDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsPublished { get; set; }
    }
}
