import { useParams } from "react-router-dom";
import { useEffect } from "react";

import { Col, Container, Row } from "react-bootstrap";

import ProgramForm from "features/Programs/ProgramForm";
import ItemsList from "features/Programs/ItemsList";
import useLectures from "features/hooks/useLectures";
import useEvents from "features/Programs/hooks/useEvents";

import { useStore } from "store";
import useProgram from "features/Programs/hooks/useProgram";

const ProgramEdit = () => {
  const { programId } = useParams();
  const { data: program } = useProgram(programId);
  const { data: events } = useEvents(programId);
  const { data: allLectures } = useLectures();

  const setItems = useStore((state) => state.setItems);

  useEffect(() => {
    return () => {
      setItems([]);
    };
    // eslint-disable-next-line
  }, []);

  return (
    <Container>
      <Row>
        <Col md={5}>
          <ProgramForm program={program} />
        </Col>
        <Col md={7}>
          <ItemsList
            allLectures={allLectures?.data}
            events={events}
            programId={programId}
          />
        </Col>
      </Row>
    </Container>
  );
};

export default ProgramEdit;
