import dayjs from "dayjs";
import { Accordion } from "react-bootstrap";

const StudentProgramDetails = ({ student }) => {
  return (
    <Accordion defaultActiveKey={["0"]} alwaysOpen>
      <Accordion.Item eventKey="0">
        <Accordion.Header>Personal Info</Accordion.Header>
        <Accordion.Body>
          First name: {student?.firstName} <br />
          Last name: {student?.lastName} <br />
          Birth date: {student?.birthDate} <br />
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey="1">
        <Accordion.Header>
          Selection Info: {student?.selection?.name}
        </Accordion.Header>
        <Accordion.Body>
          Start date:{" "}
          {dayjs(student?.selection?.startDate).format("YYYY-MM-DD")}
          <br />
          Status: {student?.selection?.status}
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey="2">
        <Accordion.Header>
          Program Info: {student?.selection?.program?.name}
        </Accordion.Header>
        <Accordion.Body>
          {student?.selection?.program?.description}
        </Accordion.Body>
      </Accordion.Item>
    </Accordion>
  );
};

export default StudentProgramDetails;
