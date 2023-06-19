import useLectures from "features/hooks/useLectures";
import ItemsList from "features/Programs/ItemsList";
import ProgramForm from "features/Programs/ProgramForm";
import { Col, Container, Row } from "react-bootstrap";

const ProgramNew = () => {
  const { data: allLectures } = useLectures();
  return (
    <Container>
      <Row>
        <Col md={5}>
          <ProgramForm />
        </Col>
        <Col md={7}>
          <ItemsList allLectures={allLectures?.data} />
        </Col>
      </Row>
    </Container>
  );
};

export default ProgramNew;
