import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import dayjs from "dayjs";

import { urlSelections } from "endpoints";

const getSelections = async (filter) => {
  if (filter) {
    const { data } = await axios.get(`${urlSelections}/${filter}`);
    return data;
  } else {
    const { data } = await axios.get(urlSelections);
    return data;
  }
};

export default function useSelections(filter) {
  return useQuery(["selections", filter], () => getSelections(filter), {
    refetchOnWindowFocus: false,
    select: (data) => {
      const selections = data?.data?.map((d) => {
        return {
          id: d.id,
          name: d.name,
          program: d?.program?.name,
          startDate: dayjs(d.startDate).format("YYYY-MM-DD"),
          status: d.status,
        };
      });
      return { pages: data?.pages, data: selections };
    },
  });
}
