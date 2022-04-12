namespace Blazor_AutoSchool.Shared
{
    public class Category
    {
        public int Id { get; set; }

        public List<Topic> Topics { get; set; } = new List<Topic>();
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
