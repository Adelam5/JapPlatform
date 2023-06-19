namespace JapPlatformBackend.Core.Dtos.Admin
{
    public class GetSelectionsSuccess
    {
        public int Id { get; set; }
        public string SelectionName { get; set; }
        public string ProgramName { get; set; }
        public double SuccessRate { get; set; }
    }
}
