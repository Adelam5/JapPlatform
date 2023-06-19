using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Admin;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using JapPlatformBackend.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JapPlatformBackend.Services
{
    public class AdminService : IAdminService
    {
        private readonly IConfiguration configuration;
        private readonly DataContext context;
        private readonly IMailService mailService;
        private readonly ISelectionRepository selectionRepository;

        public AdminService(IConfiguration configuration, DataContext context, IMailService mailService, ISelectionRepository selectionRepository)
        {
            this.configuration = configuration;
            this.context = context;
            this.mailService = mailService;
            this.selectionRepository = selectionRepository;
        }

        public async Task<ServiceResponse<GetReport>> GetReport()
        {
            var getOverallSuccess = await context.GetOverallSuccess.FromSqlRaw("GetOverallSuccess").ToListAsync();
            var getSelectionSuccess = await context.GetSelectionsSuccess.FromSqlRaw("GetSelectionsSuccess").ToListAsync();

            var report = new GetReport();
            report.OverallSuccessRate = getOverallSuccess.First().OverallSuccessRate;
            report.SelectionSuccessRate = getSelectionSuccess;

            var response = new ServiceResponse<GetReport>
            {
                Data = report,
            };

            return response;
        }

        public async Task SendEmailReport()
        {
            var adminEmail = configuration["SendGrid:AdminEmail"];
            if (string.IsNullOrEmpty(adminEmail))
            {
                throw new JapPlatformException("Admin email was not found");
            }

            var selections = await selectionRepository.GetAll();

            var selectionsEndingToday = selections.FindAll(s => s.EndDate == DateTime.Today);

            var selectionsSuccess = await context.GetSelectionsSuccess.FromSqlRaw("GetSelectionsSuccess").ToListAsync();


            foreach (GetSelectionDto selection in selectionsEndingToday)
            {
                var successRate = selectionsSuccess.First(s => s.Id == selection.Id);
                var template = EmailHelpers.CreateTemplateReport(successRate);
                await mailService.SendEmail(adminEmail, EmailHelpers.SubjectReport, template);
            }
        }

    }
}
