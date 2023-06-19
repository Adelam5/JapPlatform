import Pagination from "components/Pagination/Pagination";
import TableFilter from "components/Table/TableFilter";
import TableWrapper from "components/Table/TableWrapper";
import { tableData } from "features/Selections/Selections.data";
import SelectionsTable from "features/Selections/SelectionsTable";

const Selections = () => {
  return (
    <TableWrapper title="Selections">
      <div>
        <TableFilter tableData={tableData} />
        <SelectionsTable />
      </div>
      <Pagination />
    </TableWrapper>
  );
};

export default Selections;
