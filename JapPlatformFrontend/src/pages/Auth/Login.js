import { Col, Container, Row } from "react-bootstrap";

import LoginForm from "features/Auth/LoginForm";

const Login = () => {
  return (
    <Container
      style={{ height: "100vh" }}
      className="d-flex align-items-center"
    >
      <Row className=" w-100  justify-content-center">
        <h1 className="text-center mb-4">Login</h1>
        <Col sm={12} md={6} className="border rounded p-5 h-60 bg-light">
          <LoginForm />
        </Col>
      </Row>
    </Container>
  );
};

export default Login;
