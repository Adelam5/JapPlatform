import { tableData } from "features/Students/Students.data";

import { StudentsTable } from "features/Students";
import Pagination from "components/Pagination/Pagination";
import TableFilter from "components/Table/TableFilter";
import TableWrapper from "components/Table/TableWrapper";

const Students = () => {
  return (
    <TableWrapper title="Students">
      <div>
        <TableFilter tableData={tableData} />
        <StudentsTable />
      </div>
      <Pagination />
    </TableWrapper>
  );
};

export default Students;
