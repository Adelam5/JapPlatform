import { useState } from "react";
import { useStore } from "store";

import { Button, Form } from "react-bootstrap";

const TableFilter = ({ tableData }) => {
  const [input, setInput] = useState("");
  const [filterBy, setFilterBy] = useState("");
  const setFilter = useStore((state) => state.setFilter);
  const setValue = useStore((state) => state.setValue);
  const setPage = useStore((state) => state.setPage);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (filterBy && input) {
      setFilter(filterBy);
      setValue(input);
      setPage(1);
    } else {
      setFilter("");
    }
    setInput("");
  };

  return (
    <form onSubmit={handleSubmit} className="filter-form mb-1">
      <Form.Select
        value={filterBy}
        onChange={(e) => setFilterBy(e.target.value)}
        className="me-2"
      >
        <option value="">Filter by:</option>
        {tableData.map((data) => (
          <option key={data.prop} value={data.prop}>
            {data.header}
          </option>
        ))}
      </Form.Select>
      <Form.Control
        value={input}
        onChange={(e) => setInput(e.target.value)}
        placeholder="Search..."
        className="me-2"
      />
      <Button type="submit">Submit</Button>
    </form>
  );
};

export default TableFilter;
