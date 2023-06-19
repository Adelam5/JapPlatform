import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlItems } from "endpoints";

const deleteItem = async (itemId) => {
  const { data } = await axios.delete(`${urlItems}/${itemId}`);
  return data;
};

export default function useDeleteItem() {
  const queryClient = useQueryClient();
  return useMutation(deleteItem, {
    onSuccess: () => {
      queryClient.invalidateQueries("programs");
    },
  });
}
