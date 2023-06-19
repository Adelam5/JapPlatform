import { Col } from "react-bootstrap";

import ProgramsTable from "features/Programs/ProgramsTable";
import TableWrapper from "components/Table/TableWrapper";

const Programs = () => {
  return (
    <TableWrapper title="Programs">
      <Col className="border rounded p-3 bg-light">
        <ProgramsTable />
      </Col>
    </TableWrapper>
  );
};

export default Programs;
