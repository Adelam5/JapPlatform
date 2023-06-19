import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlRemoveStudent } from "endpoints";

const removeStudent = async (selectionStudent) => {
  const { data } = await axios.put(urlRemoveStudent, selectionStudent);
  return data;
};

export default function useRemoveStudent() {
  const queryClient = useQueryClient();
  return useMutation(removeStudent, {
    onSuccess: () => {
      queryClient.invalidateQueries("selection");
    },
  });
}
