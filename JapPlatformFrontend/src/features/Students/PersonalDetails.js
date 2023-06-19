import { Fragment } from "react";
import { Link } from "react-router-dom";

import { Button, Form } from "react-bootstrap";

import ContainerCard from "components/Card/ContainerCard";

import { tableData } from "./Students.data";

const PersonalDetails = ({ student }) => {
  return (
    <ContainerCard>
      <h3 className="mb-4">Personal Details</h3>
      {tableData.map((prop, i) => (
        <Fragment key={i}>
          <Form.Label htmlFor={prop.prop}>{prop?.header}</Form.Label>
          <Form.Control
            id={prop.prop}
            value={
              prop.prop !== "selection"
                ? student?.[prop.prop] || ""
                : student?.selection?.name || ""
            }
            readOnly
          />
        </Fragment>
      ))}
      <Button as={Link} to="edit" className="mt-3">
        Edit Student
      </Button>
    </ContainerCard>
  );
};

export default PersonalDetails;
