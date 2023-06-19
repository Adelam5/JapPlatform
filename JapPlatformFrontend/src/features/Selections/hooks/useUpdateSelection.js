import { useNavigate } from "react-router-dom";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlSelections } from "endpoints";

const updateSelection = async (selection) => {
  const { data } = await axios.put(
    `${urlSelections}/${selection.id}`,
    selection
  );
  return data;
};

export default function useUpdateSelection() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(updateSelection, {
    onSuccess: () => {
      queryClient.invalidateQueries("selections");
      navigate("/selections");
    },
  });
}
