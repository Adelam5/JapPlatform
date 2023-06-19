import { Field, Form, Formik } from "formik";

import { Button } from "react-bootstrap";

import { lectureSchema, lectureUpdateSchema } from "./Lecture.validation";
import useUpdateLecture from "./hooks/useUpdateLecture";
import useNewLecture from "./hooks/useNewLecture";

import ContainerCard from "components/Card/ContainerCard";
import InputControl from "components/Form/InputControl";
import ErrorMessage from "components/Form/ErrorMessage";

const LectureForm = ({ lecture }) => {
  const initialValues = {
    name: lecture?.name || "",
    description: lecture?.description || "",
    urls: lecture?.urls || "",
    workHours: lecture?.workHours || "",
  };

  const {
    mutate: update,
    error: updateError,
    isError: isUpdateError,
  } = useUpdateLecture();

  const { mutate: add, error: addError, isError: isAddError } = useNewLecture();

  const onSubmit = (values) => {
    if (lecture) {
      const updatedLecture = values;
      updatedLecture.id = lecture.id;
      update(updatedLecture);
    } else {
      add(values);
    }
    //
  };

  return (
    <ContainerCard>
      <h3>Lecture Details</h3>
      <ErrorMessage error={isAddError && addError.response.data.message} />
      <ErrorMessage
        error={isUpdateError && updateError.response.data.message}
      />
      <Formik
        initialValues={initialValues}
        validationSchema={lecture ? lectureUpdateSchema : lectureSchema}
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
            <Field
              label="Work Hours"
              name="workHours"
              component={InputControl}
            />
            <Field label="Urls" name="urls" component={InputControl} />
            <Button variant="primary" type="submit">
              Save
            </Button>
          </Form>
        )}
      </Formik>
    </ContainerCard>
  );
};

export default LectureForm;
