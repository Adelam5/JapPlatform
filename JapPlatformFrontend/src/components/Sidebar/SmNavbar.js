import { Link } from "react-router-dom";

import { Container, Nav, Navbar } from "react-bootstrap";

const SmNavbar = () => {
  return (
    <Navbar collapseOnSelect expand="lg" bg="light">
      <Container>
        <Navbar.Brand href="#home">JAP Platform</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Link to="/dashboard">
              <Nav.Link as="div" href="#dashboard">
                Dashboard
              </Nav.Link>
            </Link>
            <Link to="/programs">
              <Nav.Link as="div" href="#programs">
                Programs
              </Nav.Link>
            </Link>
            <Link to="/items">
              <Nav.Link as="div" href="#items">
                Program Items
              </Nav.Link>
            </Link>
            <Link to="/students">
              <Nav.Link as="div" href="#students">
                Students
              </Nav.Link>
            </Link>
            <Link to="/selections">
              <Nav.Link as="div" href="#selections">
                Selections
              </Nav.Link>
            </Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default SmNavbar;
