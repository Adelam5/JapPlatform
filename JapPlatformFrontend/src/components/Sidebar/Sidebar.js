import { Button, Col, Container, Row, Stack } from "react-bootstrap";
import { Outlet } from "react-router-dom";

import SidebarLink from "./SidebarLink";
import SmNavbar from "./SmNavbar";

import { useLogout } from "../../features/hooks/useLogout";

const Sidebar = () => {
  const { refetch: logout } = useLogout();

  return (
    <Container fluid className="m-0 p-0">
      <Row className="d-md-none">
        <SmNavbar />
      </Row>
      <Row>
        <Col md={3} className="d-none d-md-block">
          <Stack gap={5} className="h-100 text-center border-end ">
            <h1 className="my-5 py-2">JAP Platform</h1>
            <SidebarLink to="/dashboard" label="Dashboard" />
            <SidebarLink to="/programs" label="Programs" />
            <SidebarLink to="/lectures" label="Lectures" />
            <SidebarLink to="/students" label="Students" />
            <SidebarLink to="/selections" label="Selections" />
            <Button variant="outline-danger m-2" onClick={() => logout()}>
              Logout
            </Button>
          </Stack>
        </Col>
        <Col sm={12} md={9}>
          <Outlet />
        </Col>
      </Row>
    </Container>
  );
};

export default Sidebar;
