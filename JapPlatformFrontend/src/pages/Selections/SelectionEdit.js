import { useParams } from "react-router-dom";

import { Col, Container, Row } from "react-bootstrap";

import useSelection from "features/Selections/hooks/useSelection";

import SelectionForm from "features/Selections/SelectionForm";
import SelectionStudentsList from "features/Selections/SelectionStudentsList";

const SelectionEdit = () => {
  const { selectionId } = useParams();
  const { data: selection } = useSelection(selectionId);

  return (
    <Container>
      <Row>
        <Col md={5}>
          <SelectionForm selection={selection} />
        </Col>
        <Col md={7}>
          <SelectionStudentsList
            students={selection?.students}
            edit={true}
            selectionId={selection?.id}
          />
        </Col>
      </Row>
    </Container>
  );
};

export default SelectionEdit;
