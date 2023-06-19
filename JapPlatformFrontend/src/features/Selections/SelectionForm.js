import { Field, Form, Formik } from "formik";

import { Button, Row } from "react-bootstrap";

import { statusList } from "./Selections.data";
import { selectionSchema, selectionUpdateSchema } from "./Selection.validation";
import useUpdateSelection from "./hooks/useUpdateSelection";
import useNewSelection from "./hooks/useNewSelection";
import useStudentsList from "./hooks/useStudentsList";

import ContainerCard from "components/Card/ContainerCard";
import InputControl from "components/Form/InputControl";
import { SelectControl } from "components/Form/SelectControl";
import ErrorMessage from "components/Form/ErrorMessage";
import usePrograms from "features/Programs/hooks/usePrograms";

const SelectionForm = ({ selection }) => {
  const { data: programsList } = usePrograms();
  const initialValues = {
    name: selection?.name || "",
    programId: selection?.programId.id || undefined,
    startDate: selection?.startDate || "",
    endDate: selection?.endDate || "",
    status: selection?.status || "",
    studentId: "",
  };
  const {
    mutate: update,
    error: updateError,
    isError: isUpdateError,
  } = useUpdateSelection();
  const {
    mutate: add,
    error: addError,
    isError: isAddError,
  } = useNewSelection();
  const { data: studentsList } = useStudentsList();
  const onSubmit = (values) => {
    if (selection) {
      const updatedSelection = {
        id: selection.id,
        name: values?.name,
        programId: parseInt(values?.programId),
        startDate: values?.startDate,
        endDate: values?.endDate,
        status: values?.status,
      };
      update(updatedSelection);
    } else {
      add(values);
    }
    //
  };

  return (
    <ContainerCard>
      <h3>Selection Details</h3>
      <ErrorMessage error={isAddError && addError.response.data.message} />
      <ErrorMessage
        error={isUpdateError && updateError.response.data.message}
      />
      <Formik
        initialValues={initialValues}
        validationSchema={selection ? selectionUpdateSchema : selectionSchema}
        onSubmit={onSubmit}
        enableReinitialize
      >
        {() => (
          <Form>
            <Field label="Name" name="name" component={InputControl} />
            <Field
              label="Program"
              name="programId"
              options={programsList}
              component={SelectControl}
            />
            {!selection && (
              <Field
                label="Student"
                name="studentId"
                options={studentsList}
                component={SelectControl}
              />
            )}
            <Row>
              <Field
                label="Start date"
                name="startDate"
                type="date"
                component={InputControl}
                small={true}
              />
              <Field
                label="End date"
                name="endDate"
                type="date"
                component={InputControl}
                small={true}
              />
            </Row>

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

export default SelectionForm;
