import { Field, Form, Formik } from "formik";

import { Button } from "react-bootstrap";

import { programSchema } from "./Program.validation";
import useUpdateProgram from "./hooks/useUpdateProgram";
import useNewProgram from "./hooks/useNewProgram";

import ContainerCard from "components/Card/ContainerCard";
import InputControl from "components/Form/InputControl";
import ErrorMessage from "components/Form/ErrorMessage";
import { useStore } from "store";

const ProgramForm = ({ program }) => {
  const items = useStore((state) => state.items);
  const initialValues = {
    name: program?.name || "",
    description: program?.description || "",
  };

  const {
    mutate: update,
    error: updateError,
    isError: isUpdateError,
  } = useUpdateProgram();

  const { mutate: add, error: addError, isError: isAddError } = useNewProgram();

  const onSubmit = (values) => {
    if (program) {
      const updatedProgram = {
        id: program.id,
        name: values?.name,
        description: values?.description,
        itemPrograms: items,
      };
      console.log(updatedProgram);
      update(updatedProgram);
    } else {
      const newProgram = values;
      newProgram.itemPrograms = items;
      add(newProgram);
    }
    //
  };

  return (
    <ContainerCard>
      <h3>Program Details</h3>
      <ErrorMessage error={isAddError && addError.response.data.message} />
      <ErrorMessage
        error={isUpdateError && updateError.response.data.message}
      />
      <Formik
        initialValues={initialValues}
        validationSchema={programSchema}
        onSubmit={onSubmit}
        enableReinitialize
      >
        {() => (
          <Form>
            <Field label="Name" name="name" component={InputControl} />
            <Field
              label="Description"
              name="description"
              component={InputControl}
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

export default ProgramForm;
