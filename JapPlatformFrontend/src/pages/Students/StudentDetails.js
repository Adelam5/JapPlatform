import { useParams } from "react-router-dom";

import { Col, Container, Row } from "react-bootstrap";

import { CommentsList, PersonalDetails, useStudent } from "features/Students";

const StudentDetails = () => {
  const { studentId } = useParams();
  const { data: student } = useStudent(studentId);

  return (
    <Container>
      <Row>
        <Col md={7}>
          <PersonalDetails student={student} />
        </Col>
        <Col md={5}>
          <CommentsList student={student} />
        </Col>
      </Row>
    </Container>
  );
};

export default StudentDetails;
