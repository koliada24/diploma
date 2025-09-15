import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import { Register } from "./Pages/Identity/Register"
import { Login } from './Pages/Identity/Login';
import { Home } from './Pages/Home';
import { ProtectedRoute } from './Components/ProtectedRoute';
import { AuthProvider } from './Contexts/AuthContext';
import { ExamTemplates } from './Pages/Exams/ExamTemplates';
import { EditExamTemplate } from './Pages/Exams/EditExamTemplate';

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          
          <Route path='/register' element={<Register />} />
          <Route path='/login' element={<Login />} />

          <Route element={<ProtectedRoute />}>
            <Route path='/home' element={<Home />} />
            <Route path='/templates' element={<ExamTemplates />} />
            <Route path='/templates/edit/:id' element={<EditExamTemplate />} />
          </Route>

        </Routes>
      </BrowserRouter>
    </AuthProvider>
  )
}

export default App