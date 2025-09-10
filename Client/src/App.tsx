import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import { Register } from "./Pages/Register"
import { Login } from './Pages/Login';
import { Home } from './Pages/Home';
import { ProtectedRoute } from './Components/ProtectedRoute';
import { AuthProvider } from './Contexts/AuthContext';

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          
          <Route path='/register' element={<Register />} />
          <Route path='/login' element={<Login />} />

          <Route element={<ProtectedRoute />}>
            <Route path='/home' element={<Home />} />
          </Route>

        </Routes>
      </BrowserRouter>
    </AuthProvider>
  )
}

export default App