import { Stack } from "react-bootstrap";

const ContainerCard = ({ children }) => {
  return (
    <Stack className="comments d-flex justify-content-between bg-light p-4 mt-5 rounded">
      {children}
    </Stack>
  );
};

export default ContainerCard;
