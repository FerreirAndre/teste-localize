using System.Security.Claims;
using CnpjControl.Application.Contracts.Company;
using CnpjControl.Domain.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CnpjControl.Api.Controllers
{
    // Post api/company
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] string cnpj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();
            
            Console.WriteLine(userId);
            await _companyService.AddCompanyByCnpjAsync(cnpj, userId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(userId);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            
            var companies = await _companyService.GetAllCompaniesAsync(userId);
            return Ok(companies);
        }
    }
}
