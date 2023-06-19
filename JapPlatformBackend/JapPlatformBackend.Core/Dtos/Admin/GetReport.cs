namespace JapPlatformBackend.Core.Dtos.Admin
{
    public class GetReport
    {
        public double? OverallSuccessRate { get; set; }
        public List<GetSelectionsSuccess> SelectionSuccessRate { get; set; } = new();
    }
}
