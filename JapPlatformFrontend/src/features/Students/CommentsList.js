import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";

import ContainerCard from "components/Card/ContainerCard";
import CommentCard from "./CommentCard";

const CommentsList = ({ student }) => {
  return (
    <ContainerCard>
      <h3 className="mb-5">Comments</h3>
      <div>
        {student?.comments.map((comment) => (
          <CommentCard key={comment.id} comment={comment} />
        ))}
      </div>
      <Button as={Link} to="edit" className="mt-3">
        Add Comment
      </Button>
    </ContainerCard>
  );
};

export default CommentsList;
