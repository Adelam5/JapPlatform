import { getIn } from "formik";

import { Form } from "react-bootstrap";

const InputControl = ({
  field,
  form,
  label,
  placeholder,
  small,
  type = "text",
  ...props
}) => {
  const errorText =
    getIn(form.touched, field.name) && getIn(form.errors, field.name);
  return (
    <Form.Group
      className={small ? "col-md-6 mb-3" : "mb-3"}
      controlId={field.name}
    >
      <Form.Label>{label}</Form.Label>
      <Form.Control
        type={type}
        placeholder={placeholder}
        {...field}
        {...props}
      />
      <Form.Text className="text-danger">{errorText}</Form.Text>
    </Form.Group>
  );
};

export default InputControl;
