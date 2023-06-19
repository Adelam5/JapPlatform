import { useState } from "react";
import { Link } from "react-router-dom";

import { Button, Col, Form, Row } from "react-bootstrap";

import useAddStudent from "./hooks/useAddStudent";
import useStudentsList from "./hooks/useStudentsList";

import ContainerCard from "components/Card/ContainerCard";
import SelectionStudentsTable from "./SelectionStudentsTable";

const SelectionStudentsList = ({ students, edit, selectionId }) => {
  const [studentId, setStudentId] = useState("");

  const { data: studentsList } = useStudentsList();

  const { mutate: addStudent } = useAddStudent();

  return (
    <ContainerCard>
      <h3 className="mb-5"> Students List</h3>
      {edit && (
        <Row className="d-flex justify-content-center aligin-items-center">
          <Col>
            <Form.Select
              value={studentId}
              onChange={(e) => setStudentId(parseInt(e.target.value))}
            >
              <option>Choose student:</option>
              {studentsList?.map((option) => (
                <option key={option.code} value={option.code}>
                  {option.name}
                </option>
              ))}
            </Form.Select>
          </Col>
          <Col>
            <Button onClick={() => addStudent({ selectionId, studentId })}>
              Add student
            </Button>
          </Col>
        </Row>
      )}
      <div>
        {students?.length > 0 && (
          <SelectionStudentsTable
            students={students}
            edit={edit}
            selectionId={selectionId}
          />
        )}
      </div>
      {!edit && (
        <Button as={Link} to="edit" className="mt-3">
          Add Student
        </Button>
      )}
    </ContainerCard>
  );
};

export default SelectionStudentsList;
