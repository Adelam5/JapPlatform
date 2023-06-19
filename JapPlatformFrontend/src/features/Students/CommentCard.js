import { Badge, Card } from "react-bootstrap";

const dayjs = require("dayjs");
var relativeTime = require("dayjs/plugin/relativeTime");
dayjs.extend(relativeTime);

const CommentCard = ({ comment }) => {
  return (
    <Card key={comment.id} className="mt-1">
      <Card.Body>
        <Card.Text>{comment.text}</Card.Text>
      </Card.Body>
      <Card.Footer className="d-flex text-muted justify-content-between">
        <small>Written by: {comment?.author?.username}</small>
        <Badge>{dayjs(comment?.createdAt).fromNow()}</Badge>
      </Card.Footer>
    </Card>
  );
};

export default CommentCard;
