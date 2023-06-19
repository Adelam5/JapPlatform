import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import axios from "axios";

import { urlPrograms } from "endpoints";

const addProgram = async (newProgram) => {
  const { data } = await axios.post(urlPrograms, newProgram);
  return data;
};

export default function useNewProgram() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(addProgram, {
    onSuccess: () => {
      queryClient.invalidateQueries(["programs"]);
      navigate("/programs");
    },
  });
}
