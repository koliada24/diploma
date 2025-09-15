import { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import { useLogin } from "../../Hooks/Identity/useLogin";

export function Login() {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const { handleLogin, errorMessage } = useLogin();

  const submitLogin = async () => {
    await handleLogin({username, password});
  };

  return (
    <div className="center-div">
      <Form className='d-flex flex-column w-235px'>

      <Form.Group className='mb-3'>
        <Form.Label htmlFor='username'>Username</Form.Label>
        <Form.Control id='username' onChange={(e) => setUsername(e.target.value)} />
      </Form.Group>

      <Form.Group className='mb-4'>
        <Form.Label htmlFor='password'>Password</Form.Label>
        <Form.Control id='password' type='password' onChange={(e) => setPassword(e.target.value)} />
      </Form.Group>

      {errorMessage && (
        <Alert variant="danger" className="mb-3 text-center">
          {errorMessage}
        </Alert>
      )}

      <Button className='mb-3' onClick={submitLogin}>Login</Button>
      
      <div className="text-center">
        <span>Do not have an account? </span>
        <a href="/register">Sign up</a>
      </div>

      </Form>
    </div>
  )
}