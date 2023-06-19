import { Field, Formik, Form } from "formik";
import { Button } from "react-bootstrap";

import { loginSchema } from "./Login.validation";
import { useLogin } from "./useLogin";

import InputControl from "components/Form/InputControl";
import ErrorMessage from "components/Form/ErrorMessage";

const LoginForm = () => {
  const initialValues = {
    username: "",
    password: "",
  };

  const { mutate: login, error, isError } = useLogin();

  const onSubmit = (values) => {
    login(values);
  };

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={loginSchema}
      onSubmit={onSubmit}
    >
      {() => (
        <Form>
          <ErrorMessage
            error={
              isError &&
              (error.response.data.message ||
                error?.message ||
                "Server error. Please try later.")
            }
          />
          <Field label="Username" name="username" component={InputControl} />
          <Field
            label="Password"
            name="password"
            type="password"
            component={InputControl}
          />
          <Button variant="primary" type="submit">
            Login
          </Button>
        </Form>
      )}
    </Formik>
  );
};

export default LoginForm;
