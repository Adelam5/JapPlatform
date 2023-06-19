import { useEffect } from "react";
import { useStore } from "store";
import { Table } from "react-bootstrap";

import { tableData } from "./Students.data";
import useData from "features/hooks/useData";
import useStudents from "features/hooks/useStudents";
import useDeleteStudent from "./hooks/useDeleteStudent";

import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";

const StudentsTable = () => {
  const setTotalPages = useStore((state) => state.setTotalPages);
  const data = useData(useStudents);
  const { mutate: remove } = useDeleteStudent();

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

export default StudentsTable;
