import Pagination from "components/Pagination/Pagination";
import TableFilter from "components/Table/TableFilter";
import TableWrapper from "components/Table/TableWrapper";
import { tableData } from "features/Lectures/Lectures.data";
import LecturesTable from "features/Lectures/LecturesTable";

const Lectures = () => {
  return (
    <TableWrapper title="Lectures">
      <div>
        <TableFilter tableData={tableData} />
        <LecturesTable />
      </div>
      <Pagination />
    </TableWrapper>
  );
};

export default Lectures;
