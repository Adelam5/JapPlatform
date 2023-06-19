import { Col, Container, Row } from "react-bootstrap";

import { Report } from "features/Admin/Report";

const Dashboard = () => {
  return (
    <Container
      style={{ minHeight: "100vh" }}
      className="d-flex flex-column align-items-center justify-content-center"
    >
      <Row className=" w-100 p-2 flex-column justify-content-center bg-light rounded">
        <Col className="text-center mb-4">
          <h1>Dashboard</h1>
          <h4>Report</h4>
        </Col>
        <Col>
          <Report />
        </Col>
      </Row>
    </Container>
  );
};

export default Dashboard;
