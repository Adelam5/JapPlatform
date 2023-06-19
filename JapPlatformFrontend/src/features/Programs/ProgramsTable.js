import { Table } from "react-bootstrap";

import { tableData } from "./Programs.data";
import usePrograms from "./hooks/usePrograms";

import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";
import useDeleteProgram from "./hooks/useDeleteProgram";

const ProgramsTable = () => {
  const { data: programs } = usePrograms();
  const { mutate: remove } = useDeleteProgram();

  return (
    <Table responsive>
      <TableHead tableData={tableData} showActions={true} sortable={false} />
      <TableBody
        dataRows={programs}
        tableData={tableData}
        showActions={true}
        remove={remove}
      />
    </Table>
  );
};

export default ProgramsTable;
