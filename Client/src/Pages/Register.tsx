import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useRegister } from "../Hooks/useRegister";

export function Register() {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const { handleRegistration } = useRegister();

  const submitRegistration = async () => {
    await handleRegistration({ username, password});
  };

  return(
    <Form className='d-flex flex-column'>

      <Form.Group className='mb-3'>
        <Form.Label htmlFor='username'>Username</Form.Label>
        <Form.Control id='username' onChange={(e) => setUsername(e.target.value)} />
      </Form.Group>

      <Form.Group className='mb-4'>
        <Form.Label htmlFor='password'>Password</Form.Label>
        <Form.Control id='password' type='password' onChange={(e) => setPassword(e.target.value)} />
      </Form.Group>

      <Button className='mb-3' onClick={submitRegistration}>Register</Button>
      
      <div className="text-center">
        <span>Already have an account? </span>
        <a href="/login">Sign in</a>
      </div>

    </Form>
  )
}