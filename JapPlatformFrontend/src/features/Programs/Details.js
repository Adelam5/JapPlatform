import { Link } from "react-router-dom";

import { Button, Table } from "react-bootstrap";

import ContainerCard from "components/Card/ContainerCard";
import { tableData } from "./Items.data";
import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";

const Details = ({ program }) => {
  return (
    <ContainerCard>
      <h3 className="mb-4">Program Details</h3>
      Program name: {program?.name} <br />
      Created At: {program?.createdAt} <br />
      Modified At: {program?.modifiedAt} <br />
      Description: {program?.description} <br />
      <div>
        <Table size="sm" responsive>
          <TableHead tableData={tableData} sortable={false} />
          <TableBody dataRows={program?.items} tableData={tableData} />
        </Table>
      </div>
      <Button as={Link} to="edit" className="mt-3">
        Edit Program
      </Button>
    </ContainerCard>
  );
};

export default Details;
