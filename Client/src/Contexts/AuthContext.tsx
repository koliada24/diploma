import axios from "../axios";
import { createContext, useContext, useEffect, useState } from "react";
import config from "../config";

interface AuthState {
  isAuthenticated: boolean;
  currentUserName: string;
}

const defaultAuthState: AuthState = {
  isAuthenticated: false,
  currentUserName: ''
}

export const AuthContext = createContext<AuthState>(defaultAuthState);

export const useAuth = () => useContext(AuthContext);

export const AuthProvider = ({ children }: any) => {
  const [ authState, setAuthState ] = useState<AuthState>(defaultAuthState);

  useEffect(() => {
    const fetchAuthStateInfo = async() => {
      try {
        const response = await axios.get(`${config.apiUrl}/identity/me`);
        if (response.status == 200) {
          setAuthState(response.data);
        }
      }
      catch {
        // TODO: handle failed fetch username attempt
      }
    };
    fetchAuthStateInfo();
  }, []);

  return (
    <AuthContext.Provider value={authState}>
      {children}
    </AuthContext.Provider>
  );
} 