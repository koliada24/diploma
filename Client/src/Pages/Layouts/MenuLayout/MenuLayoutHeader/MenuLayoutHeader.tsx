import { Button, Container, Nav, Navbar } from "react-bootstrap";
import useMenuLayoutHeader from "./useMenuLayoutHeader";
import { UsernameWithLogo } from "./UsernameWithLogo";

export function MenuLayoutHeader() {
  const { username, handleLogout } = useMenuLayoutHeader();

  const onLogOut = async () => {
    await handleLogout();
  };

  return (
    <Navbar expand="lg" className="bg-light border-top border-end border-bottom">
      <Container>
        <Navbar.Brand></Navbar.Brand>
        <Navbar>
          <Nav className="me-auto">
            <Navbar.Text>
              <UsernameWithLogo username={username} />
            </Navbar.Text>
            <Button variant="light" onClick={onLogOut}>Log out</Button>
          </Nav>
        </Navbar>
      </Container>
    </Navbar>
  );
}