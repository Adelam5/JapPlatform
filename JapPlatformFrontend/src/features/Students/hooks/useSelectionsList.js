import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlSelections } from "endpoints";

const getSelections = async () => {
  const { data } = await axios.get(`${urlSelections}?pageSize=100`);
  return data.data;
};

export default function useSelectionsList() {
  return useQuery(["selectionsList"], () => getSelections(), {
    refetchOnWindowFocus: false,
    select: (data) =>
      data.map((d) => {
        return {
          code: d.id,
          name: d.name,
        };
      }),
  });
}
