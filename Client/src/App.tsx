import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import { Register } from "./Pages/Register"
import { Login } from './Pages/Login';
import { Home } from './Pages/Home';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/register' element={<Register />} />
        <Route path='/login' element={<Login />} />
        <Route path='/home' element={<Home />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App