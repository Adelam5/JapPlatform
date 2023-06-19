import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlAddStudent } from "endpoints";

const addStudent = async (selectionStudent) => {
  const { data } = await axios.put(urlAddStudent, selectionStudent);
  return data;
};

export default function useAddStudent() {
  const queryClient = useQueryClient();
  return useMutation(addStudent, {
    onSuccess: () => {
      queryClient.invalidateQueries("selection");
    },
  });
}
