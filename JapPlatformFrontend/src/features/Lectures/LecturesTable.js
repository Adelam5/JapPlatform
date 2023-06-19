import { useEffect } from "react";
import { useStore } from "store";

import { Table } from "react-bootstrap";

import { tableData } from "./Lectures.data";
import useLectures from "../hooks/useLectures";
import useDeleteLecture from "./hooks/useDeleteLecture";
import useData from "features/hooks/useData";

import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";

const LecturesTable = () => {
  const setTotalPages = useStore((state) => state.setTotalPages);
  const data = useData(useLectures);
  const { mutate: remove } = useDeleteLecture();

  useEffect(() => {
    if (data?.pages) {
      setTotalPages(data?.pages);
    }
    //eslint-disable-next-line
  }, [data?.pages]);
  console.log(data);
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

export default LecturesTable;
