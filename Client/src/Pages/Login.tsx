import { useState } from "react";
import { Button, Form } from "react-bootstrap";

export function Login() {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');

  const submitLogin = () => {

  };

  return (
    <Form className='d-flex flex-column'>

      <Form.Group className='mb-3'>
        <Form.Label htmlFor='username'>Username</Form.Label>
        <Form.Control id='username' onChange={(e) => setUsername(e.target.value)} />
      </Form.Group>

      <Form.Group className='mb-4'>
        <Form.Label htmlFor='password'>Password</Form.Label>
        <Form.Control id='password' type='password' onChange={(e) => setPassword(e.target.value)} />
      </Form.Group>

      <Button className='mb-3' onClick={submitLogin}>Login</Button>
      
      <div className="text-center">
        <span>Do not have an account? </span>
        <a href="/register">Sign up</a>
      </div>

    </Form>
  )
}