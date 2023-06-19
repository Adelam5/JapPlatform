import TableBody from "components/Table/TableBody";
import TableHead from "components/Table/TableHead";
import { Badge, Table } from "react-bootstrap";
import { tableData } from "./ReportTableData";
import useReport from "./useReport";

export const Report = () => {
  const { data } = useReport();
  return (
    <>
      <h5>
        Overall success rate:
        <Badge className="mx-2">{data?.overallSuccessRate}</Badge>
      </h5>
      <Table size="sm" responsive>
        <TableHead tableData={tableData} />
        <TableBody
          dataRows={data?.selectionSuccessRate}
          tableData={tableData}
        />
      </Table>
    </>
  );
};
