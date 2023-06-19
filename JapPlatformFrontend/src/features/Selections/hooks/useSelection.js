import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import dayjs from "dayjs";

import { urlSelections } from "endpoints";

const getSelection = async (selectionId) => {
  const { data } = await axios.get(`${urlSelections}/${selectionId}`);
  return data.data;
};

export default function useSelection(selectionId) {
  const queryClient = useQueryClient();
  return useQuery(
    ["selections", selectionId],
    () => getSelection(selectionId),
    {
      refetchOnWindowFocus: false,
      initialData: () => {
        const selection = queryClient
          .getQueryData(["selections", null])
          ?.find((selection) => selection.id == selectionId); // eslint-disable-line
        if (selection) {
          return selection;
        } else {
          return undefined;
        }
      },
      select: (selection) => {
        return {
          id: selection.id,
          name: selection.name,
          startDate: dayjs(selection.startDate).format("YYYY-MM-DD"),
          endDate: dayjs(selection.endDate).format("YYYY-MM-DD"),
          programId: selection?.program,
          status: selection.status,
          students: selection.students,
        };
      },
    }
  );
}
