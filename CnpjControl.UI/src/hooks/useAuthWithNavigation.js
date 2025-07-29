import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export const useAuthWithNavigation = () => {
  const auth = useAuth();
  const navigate = useNavigate();

  const logout = () => {
    auth.logout();
    navigate("/login");
  };

  return { ...auth, logout };
};
