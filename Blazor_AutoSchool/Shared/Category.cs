namespace Blazor_AutoSchool.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
