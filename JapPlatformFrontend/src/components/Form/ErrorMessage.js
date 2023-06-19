const ErrorMessage = ({ error }) => {
  return (
    <small className="d-flex justify-content-center align-items-center text-light bg-danger rounded">
      {error}
    </small>
  );
};

export default ErrorMessage;
