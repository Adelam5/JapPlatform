import { useParams } from "react-router-dom";

import { Col, Container, Row } from "react-bootstrap";

import useProgram from "features/Programs/hooks/useProgram";

import Details from "features/Programs/Details";

const ProgramDetails = () => {
  const { programId } = useParams();
  const { data: program } = useProgram(programId);
  console.log(program);
  return (
    <Container>
      <Row>
        <Col md={12}>
          <Details program={program} />
        </Col>
      </Row>
    </Container>
  );
};

export default ProgramDetails;
