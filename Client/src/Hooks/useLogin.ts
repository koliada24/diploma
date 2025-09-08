import axios from './../axios';
import type { LoginUserDTO } from '../Models/LoginUserDTO';
import config from './../config';
import { useNavigate } from 'react-router-dom';

interface useLoginResult {
  handleLogin: (LoginUserDTO: LoginUserDTO) => Promise<void>;
}

export function useLogin(): useLoginResult {
  const navigate = useNavigate();

  const handleLogin = async (LoginUserDTO: LoginUserDTO) => {
    try {
      const response = await axios.post(`${config.apiUrl}/identity/login`, LoginUserDTO);

      if (response.status === 200) {
        navigate('/home')
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