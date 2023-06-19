import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlSelections } from "endpoints";

const deleteSelection = async (selectionId) => {
  const { data } = await axios.delete(`${urlSelections}/${selectionId}`);
  return data;
};

export default function useDeleteSelection() {
  const queryClient = useQueryClient();
  return useMutation(deleteSelection, {
    onSuccess: () => {
      queryClient.invalidateQueries(["selections"]);
    },
  });
}
