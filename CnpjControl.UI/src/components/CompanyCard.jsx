import { useState } from "react";

const CompanyCard = ({ company }) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div className="flex flex-col gap-1 mt-2">
      <div className="flex justify-between items-center">
        <div>
          <h2 className="text-lg font-bold">{company.nomeEmpresarial}</h2>
          <p className="text-sm text-gray-600">{company.cnpj}</p>
        </div>
        <button
          onClick={() => setIsOpen(!isOpen)}
          className="text-blue-500 hover:underline"
        >
          {isOpen ? "Ocultar detalhes" : "Ver detalhes"}
        </button>
      </div>

      {isOpen && (
        <div className="container">
          <p><strong>Nome:</strong> {company.nomeEmpresarial}</p>
          <p><strong>Fantasia:</strong> {company.nomeFantasia}</p>
          <p><strong>Abertura:</strong> {company.abertura}</p>
          <p><strong>Situação:</strong> {company.situacao}</p>
          <p><strong>Tipo:</strong> {company.tipo}</p>
          <p><strong>Natureza Jurídica:</strong> {company.naturezaJuridica}</p>
          <p><strong>Endereço:</strong> {company.logradouro}, {company.numero} {company.complemento} - {company.bairro}, {company.municipio} - {company.uf}, {company.cep}</p>
          <p><strong>Atividade Principal:</strong> {company.atividadePrincipal}</p>
        </div>
      )}
    </div>
  );
};

export default CompanyCard;
