import { Col, Container, Row } from "react-bootstrap";

import Profile from "features/StudentProfile/Profile";
import Nav from "features/StudentProfile/Nav";

const StudentProfile = () => {
  return (
    <>
      <Nav />
      <Container>
        <Row>
          <Col>
            <Profile />
          </Col>
        </Row>
      </Container>
    </>
  );
};

export default StudentProfile;
