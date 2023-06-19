import { useLogout } from "features/hooks/useLogout";

import { Button, Container, Navbar } from "react-bootstrap";

const Nav = () => {
  const { refetch: logout } = useLogout();

  return (
    <Navbar bg="light" expand="lg">
      <Container fluid className="d-flex justify-content-between">
        <Navbar.Brand>JAP Platform</Navbar.Brand>
        <Button onClick={logout}>Logout</Button>
      </Container>
    </Navbar>
  );
};

export default Nav;
