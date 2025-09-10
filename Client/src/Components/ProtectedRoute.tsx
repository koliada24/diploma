import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../Contexts/AuthContext";

export function ProtectedRoute() {
  const { isAuthenticated, isStateUpdated } = useAuth();
  
  return isStateUpdated ? (isAuthenticated ? <Outlet /> : <Navigate to={"/login"} replace />) : null //TODO: Add spiner
}