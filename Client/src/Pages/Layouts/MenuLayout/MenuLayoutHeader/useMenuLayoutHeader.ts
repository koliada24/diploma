import axios from "../../../../axios";
import config from "../../../../config";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../../../Contexts/AuthContext";

interface useMenuLayoutHeaderProps {
  username: string;
  handleLogout: () => Promise<void>;
}

export default function useMenuLayoutHeader(): useMenuLayoutHeaderProps {
  const navigate = useNavigate();
  const authState = useAuth();

  const handleLogout = async () => {
    const response = await axios.post(`${config.apiUrl}/identity/logout`)
    if (response.status == 200) {
      navigate('/login');
    }
  }

  return {
    username: authState.currentUserName,
    handleLogout: handleLogout
  }
}