import axios from './../axios';
import type { LoginUserDTO } from '../Models/LoginUserDTO';
import config from './../config';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../Contexts/AuthContext';

interface useLoginResult {
  handleLogin: (LoginUserDTO: LoginUserDTO) => Promise<void>;
}

export function useLogin(): useLoginResult {
  const navigate = useNavigate();
  const { refreshAuth } = useAuth();

  const handleLogin = async (LoginUserDTO: LoginUserDTO) => {
    try {
      const response = await axios.post(`${config.apiUrl}/identity/login`, LoginUserDTO);

      if (response.status === 200) {
        await refreshAuth();
        navigate('/home');
      }
      else {
        // TODO: handle failed registration attempt
      }
    }
    catch {
      // TODO: handle failed registration attempt
    }
  }

  return {
    handleLogin: handleLogin
  };
}