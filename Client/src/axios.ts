import axios, { type AxiosInstance } from 'axios';
import { useNavigate } from 'react-router-dom';

interface useConfiguredAxiosProps {
  axios: AxiosInstance;
}

export default function useConfiguredAxios(): useConfiguredAxiosProps {
  const navigate = useNavigate();

  const axiosInstance = axios.create({
    withCredentials: true
  });

  axiosInstance.interceptors.response.use(
    (response) => response,
    (error) => {
      if (error.response && error.response.status === 401) {
        navigate('/login');
      }
      return Promise.reject(error);
    }
  );

  return {
    axios: axiosInstance
  }
}