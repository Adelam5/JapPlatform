import { useNavigate } from "react-router-dom";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlPrograms } from "endpoints";

const updateProgram = async (program) => {
  const { data } = await axios.put(`${urlPrograms}/${program.id}`, program);
  return data;
};

export default function useUpdateProgram() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(updateProgram, {
    onSuccess: () => {
      queryClient.invalidateQueries("programs");
      navigate("/programs");
    },
  });
}
