import axios from '../../axios';
import axiosChecker from 'axios';
import type { RegisterUserDTO } from '../../Models/Identity/RegisterUserDTO';
import config from '../../config';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../Contexts/AuthContext';
import type { AxiosError } from 'axios';
import { useState } from 'react';

interface useRegisterResult {
  handleRegistration: (registerUserDTO: RegisterUserDTO) => Promise<void>;
  errorMessage: string | undefined;
}

export function useRegister(): useRegisterResult {
  const navigate = useNavigate();
  const { refreshAuth } = useAuth();
  const [errorMessage, setErrorMessage] = useState<string | undefined>();

  const handleRegistration = async (registerUserDTO: RegisterUserDTO) => {
    try {
      const response = await axios.post(`${config.apiUrl}/identity/register`, registerUserDTO);
      if (response.status === 200) {
        await refreshAuth();
        navigate('/home');
      }
    }
    catch (err) {
      if (axiosChecker.isAxiosError(err)) {
        const axiosError = err as AxiosError<{error?: string}>;
        
        switch (axiosError.response?.status) {
          case 400: 
            setErrorMessage("Please fill out all required fields.");
            break;
          case 409:
            setErrorMessage("That username is already taken.");
            break;
          case 500:
            setErrorMessage("Server error. Please try again later.");
            break;
          default:
            setErrorMessage("Network error. Check your connection.");
        }
      }
      else {
        setErrorMessage("Something went wrong. Try again later.")
      }
    }
  }

  return {
    handleRegistration,
    errorMessage
  };
}