namespace ImageSearchBot.Entities
{
    public class QueryContext
    {
        public string? OriginalQuery { get; set; }
        public string? AlterationDisplayQuery { get; set; }
        public string? AlterationOverrideQuery { get; set; }
        public string? AlterationMethod { get; set; }
        public string? AlterationType { get; set; }
    }
}
