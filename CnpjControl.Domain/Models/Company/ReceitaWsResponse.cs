using System.Text.Json.Serialization;

namespace CnpjControl.Domain.Models.Company;

public class ReceitaWsResponse
{
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("fantasia")]
    public string? Fantasia { get; set; }
    [JsonPropertyName("cnpj")]
    public string? Cnpj { get; set; }
    [JsonPropertyName("situacao")]
    public string? Situacao { get; set; }
    [JsonPropertyName("abertura")]
    public string? Abertura { get; set; }
    [JsonPropertyName("tipo")]
    public string? Tipo { get; set; }
    [JsonPropertyName("natureza_juridica")]
    public string? NaturezaJuridica { get; set; }
    [JsonPropertyName("atividade_principal")]
    public List<AtividadePrincipal>? AtividadePrincipal { get; set; }
    [JsonPropertyName("logradouro")]
    public string? Logradouro { get; set; }
    [JsonPropertyName("numero")]
    public string? Numero { get; set; }
    [JsonPropertyName("complemento")]
    public string? Complemento { get; set; }
    [JsonPropertyName("bairro")]
    public string? Bairro { get; set; }
    [JsonPropertyName("municipio")]
    public string? Municipio { get; set; }
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }
    [JsonPropertyName("cep")]
    public string? Cep { get; set; }
}

public class AtividadePrincipal
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
