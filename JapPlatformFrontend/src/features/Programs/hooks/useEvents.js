import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { urlEvents } from "endpoints";

const getEvents = async (programId) => {
  const { data } = await axios.get(`${urlEvents}/${programId}`);
  return data.data;
};

export default function useEvents(programId) {
  return useQuery(["events", programId], () => getEvents(programId), {
    refetchOnWindowFocus: false,
  });
}
