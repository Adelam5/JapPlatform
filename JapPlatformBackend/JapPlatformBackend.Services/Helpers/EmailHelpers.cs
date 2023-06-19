using JapPlatformBackend.Core.Dtos.Admin;

namespace JapPlatformBackend.Services.Helpers
{
    public static class EmailHelpers
    {
        public const string SubjectCredentials = "JAP Platform Credentials";
        public static string CreateTemplateCredentials(string username, string password)
        {
            return $"<html><body>" +
                $"<p>Dear student</p>" +
                $"<p>Your JAP Platform profile is ready.</p>" +
                $"<p>Your credentials are: <br/> " +
                $"Username: {username}, Password: {password}</p>" +
                $"</body></html>";
        }

        public const string SubjectReport = "JAP Platform Report";
        public static string CreateTemplateReport(GetSelectionsSuccess success)
        {
            return $"<html><body>" +
                $"<h4>Report for selection: {success.SelectionName}</h4>" +
                $"<p>Selection {success.SelectionName} was part of the {success.ProgramName} program.<br />" +
                $"It has ended with success rate of: {Math.Round(success.SuccessRate, 2)}%.</p>" +
                $"</body></html>";
        }
    }
}
