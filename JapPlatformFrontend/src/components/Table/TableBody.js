import { Link } from "react-router-dom";

import { Button, ButtonGroup } from "react-bootstrap";

const TableBody = ({ dataRows, tableData, showActions, remove }) => {
  return (
    <tbody>
      {dataRows?.map((row) => (
        <tr key={row?.id || row?.name} className={row?.discriminator || ""}>
          {tableData?.map((data) => (
            <td
              key={data?.prop}
              className={data?.prop === "description" ? "wrap" : ""}
            >
              {row[data?.prop]}
            </td>
          ))}
          {showActions && (
            <td>
              <ButtonGroup>
                <Button as={Link} to={`${row?.id}`}>
                  <i className="bi bi-eye"></i>
                </Button>
                <Button as={Link} to={`${row?.id}/edit`}>
                  <i className="bi bi-pencil"></i>
                </Button>
                <Button onClick={() => remove(row?.id)}>
                  <i className="bi bi-trash"></i>
                </Button>
              </ButtonGroup>
            </td>
          )}
        </tr>
      ))}
    </tbody>
  );
};

export default TableBody;
