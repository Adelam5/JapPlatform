import { useEffect } from "react";
import { useStore } from "store";

import { Table } from "react-bootstrap";

import { tableData } from "./Selections.data";
import useSelections from "../hooks/useSelections";
import useDeleteSelection from "./hooks/useDeleteSelection";
import useData from "features/hooks/useData";

import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";

const SelectionsTable = () => {
  const setTotalPages = useStore((state) => state.setTotalPages);
  const data = useData(useSelections);
  const { mutate: remove } = useDeleteSelection();

  useEffect(() => {
    if (data?.pages) {
      setTotalPages(data?.pages);
    }
    //eslint-disable-next-line
  }, [data?.pages]);

  return (
    <Table size="sm" responsive>
      <TableHead tableData={tableData} showActions={true} />
      <TableBody
        dataRows={data?.data}
        tableData={tableData}
        showActions={true}
        remove={remove}
      />
    </Table>
  );
};

export default SelectionsTable;
