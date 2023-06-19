import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlLectures } from "endpoints";

const getLecture = async (lectureId) => {
  const { data } = await axios.get(`${urlLectures}/${lectureId}`);
  return data.data;
};

export default function useLecture(lectureId) {
  return useQuery(["lectures", lectureId], () => getLecture(lectureId), {
    refetchOnWindowFocus: false,
  });
}
