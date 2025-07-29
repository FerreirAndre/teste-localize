using CnpjControl.Domain.Models.Company;

namespace CnpjControl.Application.Contracts.Company;

public interface ICompanyService
{
    Task AddCompanyByCnpjAsync(string cnpj, string userId);
    Task<List<CompanyResponse>> GetAllCompaniesAsync(string userId);
}