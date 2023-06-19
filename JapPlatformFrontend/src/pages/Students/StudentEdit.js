import { useParams } from "react-router-dom";

import { Col, Container, Row } from "react-bootstrap";

import { NewComment, StudentFormEdit, useStudent } from "features/Students";

const StudentEdit = () => {
  const { studentId } = useParams();
  const { data: student } = useStudent(studentId);

  return (
    <Container>
      <Row>
        <Col md={7}>
          <StudentFormEdit student={student} />
        </Col>
        <Col md={5}>
          <NewComment student={student} />
        </Col>
      </Row>
    </Container>
  );
};

export default StudentEdit;
