import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import dayjs from "dayjs";

import { urlStudents } from "endpoints";

const getStudents = async (filter) => {
  if (filter) {
    const response = await axios.get(`${urlStudents}/${filter}`);
    return response.data;
  } else {
    const response = await axios.get(urlStudents);
    return response.data;
  }
};

export default function useStudents(filter) {
  return useQuery(["students", filter], () => getStudents(filter), {
    refetchOnWindowFocus: false,
    select: (data) => {
      const students = data?.data?.map((d) => {
        return {
          id: d.id,
          firstName: d.firstName,
          lastName: d.lastName,
          birthDate: dayjs(d.birthDate).format("YYYY-MM-DD"),
          selection: d?.selection?.name,
          program: d?.selection?.program?.name,
          status: d.status,
        };
      });
      return { pages: data?.pages, data: students };
    },
  });
}
