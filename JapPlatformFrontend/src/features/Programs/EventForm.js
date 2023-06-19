import { Field, Form, Formik } from "formik";

import { Button, Col, Row } from "react-bootstrap";

//import { programSchema } from "./Event.validation";
import useNewEvent from "./hooks/useNewEvent.js";

import InputControl from "components/Form/InputControl";

const EventForm = ({ programId }) => {
  const initialValues = {
    name: "",
    workHours: "",
    orderNumber: 1,
  };

  const { mutate: add } = useNewEvent();

  const onSubmit = (values) => {
    const data = { ...values, programId };
    console.log(data);
    add(data);
  };

  return (
    <Formik
      initialValues={initialValues}
      onSubmit={onSubmit}
      enableReinitialize
    >
      {() => (
        <Form>
          <Row>
            <Field
              label="Name"
              name="name"
              component={InputControl}
              small={true}
            />
            <Field
              label="Work hours"
              name="workHours"
              component={InputControl}
              small={true}
            />
          </Row>
          <Row>
            <Field
              label="Order number"
              name="orderNumber"
              component={InputControl}
              small={true}
            />
            <Col md={6} className="text-center pt-4">
              <Button variant="primary" type="submit">
                Add new event
              </Button>
            </Col>
          </Row>
          <hr />
        </Form>
      )}
    </Formik>
  );
};

export default EventForm;
