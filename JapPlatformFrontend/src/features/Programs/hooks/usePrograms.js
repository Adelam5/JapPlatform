import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { urlPrograms } from "endpoints";

const getPrograms = async (filter) => {
  if (filter) {
    const { data } = await axios.get(`${urlPrograms}/${filter}`);
    return data.data;
  } else {
    const { data } = await axios.get(urlPrograms);
    return data.data;
  }
};

export default function usePrograms(filter) {
  return useQuery(["programs", filter], () => getPrograms(filter), {
    refetchOnWindowFocus: false,
  });
}
