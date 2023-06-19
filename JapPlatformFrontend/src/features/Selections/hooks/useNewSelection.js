import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import axios from "axios";

import { urlSelections } from "endpoints";

const addSelection = async (newSelection) => {
  const { data } = await axios.post(urlSelections, newSelection);
  return data;
};

export default function useNewSelection() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(addSelection, {
    onSuccess: () => {
      queryClient.invalidateQueries(["selections"]);
      navigate("/selections");
    },
  });
}
