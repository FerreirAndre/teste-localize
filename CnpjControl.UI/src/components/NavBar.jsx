import { Link } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";

const Navbar = () => {
  const { user, logout } = useAuth();

  return (
    <header className="container" style={{ paddingTop: "1rem" }}>
      <nav className="flex" style={{ justifyContent: "space-between" }}>
        <ul>
          {user ? (
            <>
              <li><Link to="/dashboard" className="mr-4">Dashboard</Link></li>
              <li><Link onClick={logout}>Sair</Link></li>
            </>
          ) : (
            <>
              <li><Link to="/login">Entrar</Link></li>
              <li><Link to="/register">Criar conta</Link></li>
            </>
          )}
        </ul>
      </nav>
    </header >
  );
};

export default Navbar;
