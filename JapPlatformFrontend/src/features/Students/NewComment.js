import { Field, Form, Formik } from "formik";
import { Button } from "react-bootstrap";

import { commentSchema } from "./Student.validation";
import useAddComment from "./hooks/useAddComment";

import TextAreaControl from "components/Form/TextAreaControl";
import ContainerCard from "components/Card/ContainerCard";

const NewComment = ({ student }) => {
  const initialValues = {
    text: "",
  };

  const { mutate: update, error } = useAddComment();

  const onSubmit = (values) => {
    const newComment = {
      studentId: student.id,
      text: values.text,
    };
    update(newComment);
  };

  return (
    <ContainerCard>
      <h3>New Comment</h3>
      <Formik
        initialValues={initialValues}
        validationSchema={commentSchema}
        onSubmit={onSubmit}
        enableReinitialize
      >
        {() => (
          <Form>
            <Field label="Text" name="text" component={TextAreaControl} />
            <Button variant="primary" type="submit">
              Add Comment
            </Button>
            {error && <div>{error.response.data.error}</div>}
          </Form>
        )}
      </Formik>
    </ContainerCard>
  );
};

export default NewComment;
