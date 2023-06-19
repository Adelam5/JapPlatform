import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlItems } from "endpoints";

const addItem = async (newItem) => {
  const { data } = await axios.post(urlItems, newItem);
  return data;
};

export default function useNewItem() {
  const queryClient = useQueryClient();
  return useMutation(addItem, {
    onSuccess: () => {
      queryClient.invalidateQueries(["items"]);
    },
  });
}
