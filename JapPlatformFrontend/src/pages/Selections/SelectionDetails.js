import { useParams } from "react-router-dom";

import { Col, Container, Row } from "react-bootstrap";

import useSelection from "features/Selections/hooks/useSelection";

import SelectionStudentsList from "features/Selections/SelectionStudentsList";
import Details from "features/Selections/Details";

const SelectionDetails = () => {
  const { selectionId } = useParams();
  const { data: selection } = useSelection(selectionId);
  return (
    <Container>
      <Row>
        <Col md={5}>
          <Details selection={selection} />
        </Col>
        <Col md={7}>
          <SelectionStudentsList students={selection?.students} />
        </Col>
      </Row>
    </Container>
  );
};

export default SelectionDetails;
