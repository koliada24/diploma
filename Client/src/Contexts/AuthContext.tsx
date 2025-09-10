import axios from "../axios";
import { createContext, useContext, useEffect, useState } from "react";
import config from "../config";

interface AuthState {
  isAuthenticated: boolean;
  currentUserName: string;
  isStateUpdated: boolean;
  refreshAuth: () => Promise<void>;
}

const defaultAuthState: AuthState = {
  isAuthenticated: false,
  currentUserName: '',
  isStateUpdated: false,
  refreshAuth: async () => { },
}

export const AuthContext = createContext<AuthState>(defaultAuthState);

export const useAuth = () => useContext(AuthContext);

export const AuthProvider = ({ children }: any) => {
  const [ authState, setAuthState ] = useState<AuthState>(defaultAuthState);

  const refreshAuth = async() => {
    try {
      const response = await axios.get(`${config.apiUrl}/identity/me`);
      if (response.status == 200) {
        setAuthState({
          isAuthenticated: response.data.isAuthenticated,
          currentUserName: response.data.currentUserName,
          isStateUpdated: true,
          refreshAuth: refreshAuth
        });
      }
    }
    catch {
      // TODO: handle failed fetch username attempt
    }
  };

  useEffect(() => {
    refreshAuth();
  }, []);

  return (
    <AuthContext.Provider value={authState}>
      {children}
    </AuthContext.Provider>
  );
} 