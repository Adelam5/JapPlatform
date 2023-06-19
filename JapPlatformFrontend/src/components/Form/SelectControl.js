import { getIn } from "formik";

import { Form } from "react-bootstrap";

export const SelectControl = ({
  field,
  form,
  options,
  label,
  placeholder,
  small,
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
      <Form.Select id={field.name} {...field} {...props}>
        <option>Choose:</option>
        {options?.map((option) => (
          <option
            key={option.code || option.id}
            value={option.code || option.id}
          >
            {option.name}
          </option>
        ))}
      </Form.Select>
      <Form.Text className="text-danger">{errorText}</Form.Text>
    </Form.Group>
  );
};
