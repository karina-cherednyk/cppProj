namespace g4m4nez.Utils
{
    public interface ITab
    {
        string TabName { get; set; }
    }

    public abstract class Tab : ITab
    {
        public string TabName { get; set; }
    }
}