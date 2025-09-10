import { useEffect, useState } from "react";
import axios from "../../../../axios";
import config from "../../../../config";
import { useNavigate } from "react-router-dom";

interface useMenuLayoutHeaderProps {
  username: string;
  handleLogout: () => Promise<void>;
}

export default function useMenuLayoutHeader(): useMenuLayoutHeaderProps {
  const navigate = useNavigate();

  const [ username, setUsername ] = useState<string>('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(`${config.apiUrl}/identity/me`);
        if (response.status == 200) {
          setUsername(response.data);
        }
      }
      catch {
        // TODO: handle failed fetch username attempt
      }
    };

    fetchData();
  }, []);

  const handleLogout = async () => {
    const response = await axios.post(`${config.apiUrl}/identity/logout`)
    if (response.status == 200) {
      navigate('/login');
    }
  }

  return {
    username: username,
    handleLogout: handleLogout
  }
}