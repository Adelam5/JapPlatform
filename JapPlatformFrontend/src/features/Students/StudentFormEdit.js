import { Field, Form, Formik } from "formik";

import { Button } from "react-bootstrap";

import { statusList } from "./Students.data";
import { studentSchema } from "./Student.validation";
import useUpdateStudent from "./hooks/useUpdateStudent";
import useSelectionsList from "./hooks/useSelectionsList";

import InputControl from "components/Form/InputControl";
import { SelectControl } from "components/Form/SelectControl";
import ContainerCard from "components/Card/ContainerCard";
import ErrorMessage from "components/Form/ErrorMessage";

const StudentFormEdit = ({ student }) => {
  const initialValues = {
    firstName: student?.firstName || "",
    lastName: student?.lastName || "",
    birthDate: student?.birthDate || "",
    selectionId: student?.selection?.id || undefined,
    status: student?.status || "",
  };

  const { mutate: update, error, isError } = useUpdateStudent();
  const { data: selections } = useSelectionsList();

  const onSubmit = (values) => {
    const updatedStudent = {
      id: student.id,
      firstName: values.firstName,
      lastName: values.lastName,
      birthDate: new Date(values.birthDate),
      selectionId: values.selectionId,
      status: values.status,
    };
    values.id = student.id;
    values.birthDate = new Date(values.birthDate);
    console.log(updatedStudent, values);
    update(updatedStudent);
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
            <Field
              label="First name"
              name="firstName"
              component={InputControl}
            />
            <Field label="Last name" name="lastName" component={InputControl} />
            <Field
              label="Birth date"
              name="birthDate"
              type="date"
              component={InputControl}
            />
            <Field
              label="Selection"
              name="selectionId"
              options={selections}
              component={SelectControl}
            />
            <Field
              label="Status"
              name="status"
              options={statusList}
              component={SelectControl}
            />
            <Button variant="primary" type="submit">
              Save
            </Button>
          </Form>
        )}
      </Formik>
    </ContainerCard>
  );
};

export default StudentFormEdit;
