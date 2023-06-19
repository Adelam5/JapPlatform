import LectureForm from "features/Lectures/LectureForm";
import { Col, Container, Row } from "react-bootstrap";

const LectureNew = () => {
  return (
    <Container>
      <Row>
        <Col>
          <LectureForm />
        </Col>
      </Row>
    </Container>
  );
};

export default LectureNew;
