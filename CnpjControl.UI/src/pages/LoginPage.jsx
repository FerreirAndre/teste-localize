import { useState } from "react";
import { useAuth } from "../contexts/AuthContext";

const LoginPage = () => {
  const [form, setForm] = useState({ email: "", password: "" });
  const [error, setError] = useState("");
  const { login } = useAuth();

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const response = await fetch("http://localhost:5258/api/Auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(form),
      });
      if (!response.ok) throw new Error("Login inválido");

      const data = await response.json();
      login(data)
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <main className="container" style={{ maxWidth: "500px", margin: "0 auto", paddingTop: "2rem" }}>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Email
          <input type="email" name="email" value={form.email} onChange={handleChange} required />
        </label>
        <label>
          Senha
          <input type="password" name="password" value={form.password} onChange={handleChange} required />
        </label>
        <button type="submit">Entrar</button>
        {error && <small style={{ color: "red" }}>{error}</small>}
      </form>
      <p>
        Não tem conta? <a href="/register">Cadastre-se</a>
      </p>
    </main>
  );
};

export default LoginPage;

