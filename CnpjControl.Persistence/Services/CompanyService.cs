using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Text.RegularExpressions;
using CnpjControl.Application.Contracts.Company;
using CnpjControl.Domain.Models.Company;
using CnpjControl.Domain.Models.Exceptions;
using CnpjControl.Persistence.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CnpjControl.Persistence.Services;

public class CompanyService : ICompanyService
{
    private readonly AppDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;

    public CompanyService(
        AppDbContext context,
        IHttpClientFactory httpClientFactory)

    {
        _context = context;
        _httpClientFactory = httpClientFactory;
    }

    public async Task AddCompanyByCnpjAsync(string cnpj, string userId)
    {
        var cnpjs = await _context.Companies
            .Select(c => c.Cnpj)
            .ToListAsync();

        if (cnpjs.Any(c => Regex.Replace(c, "[^0-9]", "") == cnpj))
        {
            throw new BadRequestException($"Already exists company {cnpj}");
        }

        var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
        if (!userExists)
        {
            throw new ArgumentException($"User {userId} not found");
        }
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetFromJsonAsync<ReceitaWsResponse>($"https://www.receitaws.com.br/v1/cnpj/{cnpj}");
        
        var company = new Company
        {
            UserId = userId,
            Nome = response.Nome ?? "Não informado",
            Fantasia = response.Fantasia ?? "Não informado",
            Cnpj = response.Cnpj ?? cnpj,
            Situacao = response.Situacao ?? "Desconhecida",
            Abertura = response.Abertura ?? "",
            Tipo = response.Tipo ?? "",
            NaturezaJuridica = response.NaturezaJuridica ?? "",
            AtividadePrincipal = response.AtividadePrincipal?.FirstOrDefault()?.Text ?? "Não informada",
            Logradouro = response.Logradouro ?? "",
            Numero = response.Numero ?? "",
            Complemento = response.Complemento ?? "",
            Bairro = response.Bairro ?? "",
            Municipio = response.Municipio ?? "",
            Uf = response.Uf ?? "",
            Cep = response.Cep ?? ""
        };
        
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CompanyResponse>> GetAllCompaniesAsync(string userId)
    {
        return await _context.Companies
            .Where(c => c.UserId == userId)
            .Select(c => new CompanyResponse
            {
                Id = c.Id,
                NomeEmpresarial = c.Nome,
                NomeFantasia = c.Fantasia,
                Cnpj = c.Cnpj,
                Situacao = c.Situacao,
                Abertura = c.Abertura,
                Tipo = c.Tipo,
                NaturezaJuridica = c.NaturezaJuridica,
                AtividadePrincipal = c.AtividadePrincipal,
                Logradouro = c.Logradouro,
                Numero = c.Numero,
                Complemento = c.Complemento,
                Bairro = c.Bairro,
                Municipio = c.Municipio,
                Uf = c.Uf,
                Cep = c.Cep
            })
            .ToListAsync();
    }
}