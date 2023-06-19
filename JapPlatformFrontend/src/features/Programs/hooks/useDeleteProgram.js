import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlPrograms } from "endpoints";

const deleteProgram = async (programId) => {
  const { data } = await axios.delete(`${urlPrograms}/${programId}`);
  return data;
};

export default function useDeleteProgram() {
  const queryClient = useQueryClient();
  return useMutation(deleteProgram, {
    onSuccess: () => {
      queryClient.invalidateQueries(["programs"]);
    },
  });
}
