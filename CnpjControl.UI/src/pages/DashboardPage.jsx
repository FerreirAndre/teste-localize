import { useEffect, useState } from "react";
import CompanyCard from "../components/CompanyCard";

const API_URL = "http://localhost:5258/api/company";
const CNPJ_REGEX = /^\d{14}$/;
const clean = (value) => value.replace(/[^\d]/g, "");

const DashboardPage = () => {
  const [cnpj, setCnpj] = useState("");
  const [companies, setCompanies] = useState([]);
  const [error, setError] = useState("");
  const [token, setToken] = useState(localStorage.getItem("token"));

  useEffect(() => {
    if (!token) return;

    fetch(API_URL, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => res.json())
      .then(setCompanies)
      .catch(() => setError("Erro ao carregar empresas"));
  }, [token]);

  const handleRegister = async (e) => {
    e.preventDefault();
    setError("");

    const cleanCnpj = clean(cnpj);
    console.log(cleanCnpj)
    if (!CNPJ_REGEX.test(cleanCnpj)) {
      setError("CNPJ inválido (somente números, 14 dígitos)");
      return;
    }

    try {
      const res = await fetch(API_URL, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(cleanCnpj),
      });

      if (!res.ok) {
        const errorData = await res.json();
        throw new Error(errorData.message || "Erro desconhecido");
      }

      setCnpj("");

      const getRes = await fetch(API_URL, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      const updatedCompanies = await getRes.json();
      setCompanies(updatedCompanies);

    } catch (err) {
      setError(err.message);
    }
  };
  return (
    <main className="container">
      <h2>Dashboard</h2>

      <form onSubmit={handleRegister}>
        <label>
          CNPJ
          <input
            type="text"
            name="cnpj"
            value={cnpj}
            onChange={(e) => setCnpj(e.target.value)}
            placeholder="Digite o CNPJ"
            required
          />
        </label>
        <button type="submit">Cadastrar Empresa</button>
        {error && <small style={{ color: "red" }}>{error}</small>}
      </form>

      <h3>Empresas cadastradas</h3>
      {companies.length === 0 ? (
        <p>Nenhuma empresa cadastrada ainda.</p>
      ) : (
        <div style={{
          display: "grid",
          gridTemplateColumns: "repeat(auto-fit, minmax(300px, 1fr))",
          gap: "1rem"
        }}>
          {companies.map((company) => (
            <CompanyCard key={company.cnpj} company={company} />
          ))}
        </div>)}
    </main>
  );
};

export default DashboardPage;

