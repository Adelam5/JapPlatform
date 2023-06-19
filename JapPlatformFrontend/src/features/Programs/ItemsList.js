import ContainerCard from "components/Card/ContainerCard";
import { Button, Form } from "react-bootstrap";
import { useStore } from "store";
import EventForm from "./EventForm";
import useDeleteItem from "./hooks/useDeleteItem";

const ItemsList = ({ allLectures, events, programId }) => {
  const items = useStore((state) => state.items);
  const setItems = useStore((state) => state.setItems);

  const { mutate: remove } = useDeleteItem();

  const handleCheckChange = (e, item) => {
    console.log(e.target.checked);
    if (e.target.checked) {
      setItems([
        ...items,
        { itemId: item.id, orderNumber: item.orderNumber || 1 },
      ]);
    } else {
      setItems(items.filter((p) => p.itemId !== item.id));
    }
  };

  const handleSelectChange = (e, i) => {
    const editedItems = items?.map((item) => {
      if (item.itemId === i.id) {
        item.orderNumber = parseInt(e.target.value);
      }
      return item;
    });
    setItems(editedItems);
  };

  return (
    <ContainerCard>
      <h5>Add program items</h5>
      {programId && (
        <>
          <EventForm programId={programId} />
          <table>
            <thead>
              <tr>
                <th>Event name</th>
                <th>Order number</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {events?.map((i) => (
                <tr key={i?.id} className="my-2">
                  <td>{i?.name}</td>
                  <td>
                    <select
                      onChange={(e) => handleSelectChange(e, i)}
                      value={
                        items?.find((item) => item?.itemId === i.id)
                          ?.orderNumber || 1
                      }
                    >
                      {[...new Array(10)]?.map((item, index) => (
                        <option key={index} value={index + 1}>
                          {index + 1}
                        </option>
                      ))}
                    </select>
                  </td>
                  <td>
                    <Button onClick={() => remove(i?.id)}>
                      <i className="bi bi-trash"></i>
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </>
      )}
      <table>
        <thead>
          <tr>
            <th>Lecture name</th>
            <th>Order number</th>
          </tr>
        </thead>
        <tbody>
          {allLectures?.map((i) => (
            <tr key={i?.id} className="my-2">
              <td>
                <Form.Check
                  type="checkbox"
                  label={i?.name}
                  value={i.id}
                  onChange={(e) => handleCheckChange(e, i)}
                  checked={items?.map((item) => item?.itemId).includes(i.id)}
                />
              </td>
              <td>
                <select
                  onChange={(e) => handleSelectChange(e, i)}
                  value={
                    items?.find((item) => item?.itemId === i.id)?.orderNumber ||
                    1
                  }
                >
                  {[...new Array(10)]?.map((item, index) => (
                    <option key={index} value={index + 1}>
                      {index + 1}
                    </option>
                  ))}
                </select>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </ContainerCard>
  );
};

export default ItemsList;
