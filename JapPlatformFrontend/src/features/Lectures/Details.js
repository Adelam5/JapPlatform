import { Fragment } from "react";
import { Link } from "react-router-dom";

import { Button, Form } from "react-bootstrap";

import { tableData } from "./Lectures.data";

import ContainerCard from "components/Card/ContainerCard";

const Details = ({ lecture }) => {
  return (
    <ContainerCard>
      <h3 className="mb-4">Lecture Details</h3>
      {tableData.map((prop, i) => (
        <Fragment key={i}>
          <Form.Label htmlFor={prop.prop}>{prop?.header}</Form.Label>
          <Form.Control
            id={prop.prop}
            value={
              prop.prop !== "program"
                ? lecture?.[prop.prop] || ""
                : lecture?.programId?.name || ""
            }
            readOnly
          />
        </Fragment>
      ))}
      <Button as={Link} to="edit" className="mt-3">
        Edit Lecture
      </Button>
    </ContainerCard>
  );
};

export default Details;
