import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlStudents } from "endpoints";

const getStudents = async () => {
  const { data } = await axios.get(`${urlStudents}?pageSize=100`);
  return data;
};

export default function useStudentsList() {
  return useQuery(["studentsList"], () => getStudents(), {
    refetchOnWindowFocus: false,
    select: (data) => {
      return data?.data?.map((d) => {
        return {
          code: d.id,
          name: `${d.firstName} ${d.lastName}`,
        };
      });
    },
  });
}
