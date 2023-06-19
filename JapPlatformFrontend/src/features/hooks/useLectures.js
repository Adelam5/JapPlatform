import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlLectures } from "endpoints";

const getLectures = async (filter) => {
  if (filter) {
    const { data } = await axios.get(`${urlLectures}/${filter}`);
    return data;
  } else {
    const { data } = await axios.get(urlLectures);
    return data;
  }
};

export default function useLectures(filter) {
  return useQuery(["lectures", filter], () => getLectures(filter), {
    refetchOnWindowFocus: false,
  });
}
