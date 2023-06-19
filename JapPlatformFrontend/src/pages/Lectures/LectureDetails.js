import { useParams } from "react-router-dom";

import { Col, Container, Row } from "react-bootstrap";

import useLecture from "features/Lectures/hooks/useLecture";

import Details from "features/Lectures/Details";

const LectureDetails = () => {
  const { lectureId } = useParams();
  const { data: lecture } = useLecture(lectureId);
  return (
    <Container>
      <Row>
        <Col md={5}>
          <Details lecture={lecture} />
        </Col>
        <Col md={7}></Col>
      </Row>
    </Container>
  );
};

export default LectureDetails;
