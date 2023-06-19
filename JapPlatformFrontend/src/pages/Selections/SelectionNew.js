import SelectionForm from "features/Selections/SelectionForm";
import { Col, Container, Row } from "react-bootstrap";

const SelectionNew = () => {
  return (
    <Container>
      <Row>
        <Col>
          <SelectionForm />
        </Col>
      </Row>
    </Container>
  );
};

export default SelectionNew;
