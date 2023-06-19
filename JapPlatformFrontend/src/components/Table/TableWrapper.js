import { Link } from "react-router-dom";
import { useStore } from "store";

import { Button, Col, Container, Row } from "react-bootstrap";

const TableWrapper = ({ children, title }) => {
  const pageSize = useStore((state) => state.pageSize);
  return (
    <Container className="mt-5 d-flex flex-column align-items-center justify-content-center">
      <Row className=" w-100  flex-column justify-content-center">
        <Col className="d-flex justify-content-between align-items-center">
          <h1 className="text-center mb-4">{title}</h1>
          <Button as={Link} to="new">
            Add <i className="bi bi-plus"></i>
          </Button>
        </Col>
        <Col
          className={`table-container-${pageSize} border rounded p-3 bg-light d-flex flex-column justify-content-between`}
        >
          {children}
        </Col>
      </Row>
    </Container>
  );
};

export default TableWrapper;
