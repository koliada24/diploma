import axios from './../axios';
import type { RegisterUserDTO } from '../Models/RegisterUserDTO';
import config from './../config';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../Contexts/AuthContext';

interface useRegisterResult {
  handleRegistration: (registerUserDTO: RegisterUserDTO) => Promise<void>;
}

export function useRegister(): useRegisterResult {
  const navigate = useNavigate();
  const { refreshAuth } = useAuth();

  const handleRegistration = async (registerUserDTO: RegisterUserDTO) => {
    try {
      const response = await axios.post(`${config.apiUrl}/identity/register`, registerUserDTO);

      if (response.status === 200) {
        await refreshAuth();
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
    handleRegistration
  };
}