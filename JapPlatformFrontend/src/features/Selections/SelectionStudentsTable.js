import { Link } from "react-router-dom";

import { Button, Table } from "react-bootstrap";

import useRemoveStudent from "./hooks/useRemoveStudent";

const SelectionStudentsTable = ({ students, edit, selectionId }) => {
  const { mutate: removeStudent } = useRemoveStudent();

  return (
    <Table size="sm" responsive>
      <thead>
        <tr>
          <th>First name</th>
          <th>Last name</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {students?.map((student) => (
          <tr key={student.id}>
            <td>{student.firstName}</td>
            <td>{student.lastName}</td>
            <td>{student.status}</td>
            <td>
              {edit ? (
                <Button
                  onClick={() =>
                    removeStudent({
                      selectionId,
                      studentId: student.id,
                    })
                  }
                  size="sm"
                >
                  Remove
                </Button>
              ) : (
                <Button size="sm" as={Link} to={`/students/${student.id}`}>
                  Details
                </Button>
              )}
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default SelectionStudentsTable;
