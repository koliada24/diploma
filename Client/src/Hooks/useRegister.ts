import axios from 'axios';
import type { RegisterUserDTO } from '../Models/RegisterUserDTO';
import config from './../config';
import { useNavigate } from 'react-router-dom';

interface useRegisterResult {
  handleRegistration: (registerUserDTO: RegisterUserDTO) => Promise<void>;
}

export function useRegister(): useRegisterResult {
  const navigate = useNavigate();

  const handleRegistration = async (registerUserDTO: RegisterUserDTO) => {
    try {
      console.log('called');
      const response = await axios.post(`${config.apiUrl}/identity/register`, registerUserDTO);

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
    handleRegistration
  };
}