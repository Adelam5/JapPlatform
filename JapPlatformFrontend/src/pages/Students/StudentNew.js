import { Col, Container, Row } from "react-bootstrap";

import { StudentFormNew } from "features/Students";

const StudentNew = () => {
  return (
    <Container>
      <Row>
        <Col>
          <StudentFormNew />
        </Col>
      </Row>
    </Container>
  );
};

export default StudentNew;
