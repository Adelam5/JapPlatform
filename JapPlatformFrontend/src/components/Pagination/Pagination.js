import { Button, ButtonGroup } from "react-bootstrap";

import { useStore } from "store";

const Pagination = () => {
  const page = useStore((state) => state.page);
  const setPage = useStore((state) => state.setPage);
  const totalPages = useStore((state) => state.totalPages);
  const pageSize = useStore((state) => state.pageSize);
  const setPageSize = useStore((state) => state.setPageSize);

  const handlePageSize = (e) => {
    setPageSize(parseInt(e.target.value));
    setPage(1);
  };
  return (
    <div className="pagination-resp">
      <span className="">
        Rows per page:
        <select
          className="mx-3"
          value={pageSize}
          onChange={(e) => handlePageSize(e)}
        >
          <option value={2}>2</option>
          <option value={5}>5</option>
          <option value={10}>10</option>
        </select>
      </span>

      <span className="my-2 mx-3">
        Page: {page} of {totalPages}
      </span>

      <ButtonGroup size="sm">
        <Button onClick={() => setPage(1)} disabled={page <= 1}>
          <i className="bi bi-chevron-bar-left"></i>
        </Button>
        <Button onClick={() => setPage(page - 1)} disabled={page <= 1}>
          <i className="bi bi-chevron-left"></i>
        </Button>
        <Button onClick={() => setPage(page + 1)} disabled={page >= totalPages}>
          <i className="bi bi-chevron-right"></i>
        </Button>
        <Button
          onClick={() => setPage(totalPages)}
          disabled={page >= totalPages}
        >
          <i className="bi bi-chevron-bar-right"></i>
        </Button>
      </ButtonGroup>
    </div>
  );
};

export default Pagination;
