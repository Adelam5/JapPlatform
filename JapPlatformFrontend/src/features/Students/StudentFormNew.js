import { Field, Form, Formik } from "formik";
import { Button, Row } from "react-bootstrap";

import { statusList } from "./Students.data";
import { studentSchema } from "./Student.validation";
import useNewStudent from "./hooks/useNewStudent";
import useSelectionsList from "./hooks/useSelectionsList";

import InputControl from "components/Form/InputControl";
import { SelectControl } from "components/Form/SelectControl";
import ContainerCard from "components/Card/ContainerCard";
import ErrorMessage from "components/Form/ErrorMessage";

const StudentFormNew = () => {
  const initialValues = {
    firstName: "",
    lastName: "",
    birthDate: "",
    selectionId: undefined,
    status: "",
    username: "",
    email: "",
    password: "",
  };

  const { mutate: add, error, isError } = useNewStudent();
  const { data: selections } = useSelectionsList();

  const onSubmit = (values) => {
    add(values);
  };

  return (
    <ContainerCard>
      <h3>Personal Details</h3>
      <ErrorMessage error={isError && error.response.data.message} />
      <Formik
        initialValues={initialValues}
        validationSchema={studentSchema}
        onSubmit={onSubmit}
        enableReinitialize
      >
        {() => (
          <Form>
            <Row>
              <Field
                label="First name"
                name="firstName"
                component={InputControl}
                small={true}
              />
              <Field
                label="Last name"
                name="lastName"
                component={InputControl}
                small={true}
              />
            </Row>
            <Field
              label="Birth date"
              name="birthDate"
              type="date"
              component={InputControl}
            />
            <Row>
              <Field
                label="Username"
                name="username"
                component={InputControl}
                small={true}
              />
              <Field
                label="Password"
                name="password"
                type="password"
                component={InputControl}
                small={true}
              />
            </Row>
            <Field
              label="Email"
              name="email"
              type="email"
              component={InputControl}
            />
            <Row>
              <Field
                label="Selection"
                name="selectionId"
                options={selections}
                component={SelectControl}
                small={true}
              />

              <Field
                label="Status"
                name="status"
                options={statusList}
                component={SelectControl}
                small={true}
              />
            </Row>

            <Button variant="primary" type="submit">
              Save
            </Button>
          </Form>
        )}
      </Formik>
    </ContainerCard>
  );
};

export default StudentFormNew;
