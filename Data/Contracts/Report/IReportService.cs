using Data.DTOs.Report;

namespace Data.Contracts.Report;
public interface IReportService
{
    Task<AdminDashboardReportDto> GetAdminDashboardReportAsync();
}
