import { Fragment } from "react";
import { Link } from "react-router-dom";

import { Button, Form } from "react-bootstrap";

import { tableData } from "./Selections.data";

import ContainerCard from "components/Card/ContainerCard";

const Details = ({ selection }) => {
  return (
    <ContainerCard>
      <h3 className="mb-4">Selection Details</h3>
      {tableData.map((prop, i) => (
        <Fragment key={i}>
          <Form.Label htmlFor={prop.prop}>{prop?.header}</Form.Label>
          <Form.Control
            id={prop.prop}
            value={
              prop.prop !== "program"
                ? selection?.[prop.prop] || ""
                : selection?.programId?.name || ""
            }
            readOnly
          />
        </Fragment>
      ))}
      <Button as={Link} to="edit" className="mt-3">
        Edit Selection
      </Button>
    </ContainerCard>
  );
};

export default Details;
