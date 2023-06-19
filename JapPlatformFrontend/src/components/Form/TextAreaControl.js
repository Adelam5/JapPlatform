import { getIn } from "formik";

import { Form } from "react-bootstrap";

const TextAreaControl = ({
  field,
  form,
  label,
  placeholder,
  type = "text",
  ...props
}) => {
  const errorText =
    getIn(form.touched, field.name) && getIn(form.errors, field.name);
  return (
    <Form.Group className="mb-3" controlId={field.name}>
      <Form.Label>{label}</Form.Label>
      <Form.Control
        as="textarea"
        type={type}
        placeholder={placeholder}
        {...field}
        {...props}
      />
      <Form.Text className="text-danger">{errorText}</Form.Text>
    </Form.Group>
  );
};

export default TextAreaControl;
