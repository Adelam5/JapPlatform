import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlEvents } from "endpoints";

const addEvent = async (eventData) => {
  const { data } = await axios.post(`${urlEvents}/new`, eventData);
  return data;
};

export default function useNewEvent() {
  const queryClient = useQueryClient();
  return useMutation(addEvent, {
    onSuccess: () => {
      queryClient.invalidateQueries("programs");
    },
  });
}
