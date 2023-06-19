import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";
import { Table } from "react-bootstrap";
import { tableData } from "./StudentProfile.data";

const PersonalProgramTable = ({ items }) => {
  return (
    <Table responsive>
      <TableHead tableData={tableData} />
      <TableBody dataRows={items} tableData={tableData} />
    </Table>
  );
};

export default PersonalProgramTable;
