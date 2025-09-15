import axios from '../../axios';
import axiosChecker, { AxiosError } from 'axios';
import type { LoginUserDTO } from '../../Models/Identity/LoginUserDTO';
import config from '../../config';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../Contexts/AuthContext';
import { useState } from 'react';

interface useLoginResult {
  handleLogin: (LoginUserDTO: LoginUserDTO) => Promise<void>;
  errorMessage: string | undefined;
}

export function useLogin(): useLoginResult {
  const navigate = useNavigate();
  const { refreshAuth } = useAuth();
  const [errorMessage, setErrorMessage] = useState<string | undefined>();

  const handleLogin = async (LoginUserDTO: LoginUserDTO) => {
    try {
      const response = await axios.post(`${config.apiUrl}/identity/login`, LoginUserDTO);

      if (response.status === 200) {
        await refreshAuth();
        navigate('/home');
      }
    }
    catch (err) {
      if (axiosChecker.isAxiosError(err)) {
        const axiosError = err as AxiosError;

        switch (axiosError.response?.status) {
          case 400: 
            setErrorMessage("Please fill out all required fields.");
            break;
          case 401: 
            setErrorMessage("Username or password is invalid.");
            break;
          case 500:
            setErrorMessage("Server error. Please try again later.");
            break;
          default:
            setErrorMessage("Network error. Check your connection.");
        }
      }
      else {
        setErrorMessage("Something went wrong. Try again later.");
      }
    }
  }

  return {
    handleLogin: handleLogin,
    errorMessage: errorMessage
  };
}