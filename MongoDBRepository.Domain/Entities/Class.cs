namespace MongoDBRepository.Domain.Entities
{
    public class Class : BaseEntity
    {
        public DateTime ClassDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public Teacher Teacher { get; set; } = new();
        public List<Student> Students { get; set; } = new();
    }
}
