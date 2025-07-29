import { useState } from "react";
import { useNavigate } from "react-router-dom";

const RegisterPage = () => {
  const [form, setForm] = useState({
    firstName: "",
    lastName: "",
    userName: "",
    email: "",
    password: "",
  });
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const response = await fetch("http://localhost:5258/api/Auth/register", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(form),
      });

      if (!response.ok) throw new Error("Erro ao registrar");

      navigate("/login");
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <main className="container">
      <h2>Cadastro</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Nome
          <input type="text" name="firstName" value={form.firstName} onChange={handleChange} required />
        </label>
        <label>
          Sobrenome
          <input type="text" name="lastName" value={form.lastName} onChange={handleChange} required />
        </label>
        <label>
          Nome de Usuário
          <input type="text" name="userName" value={form.userName} onChange={handleChange} required />
        </label>
        <label>
          Email
          <input type="email" name="email" value={form.email} onChange={handleChange} required />
        </label>
        <label>
          Senha
          <input type="password" name="password" value={form.password} onChange={handleChange} required />
        </label>
        <button type="submit">Registrar</button>
        {error && <small style={{ color: "red" }}>{error}</small>}
      </form>
      <p>
        Já tem conta? <a href="/login">Entrar</a>
      </p>
    </main>
  );
};

export default RegisterPage;

