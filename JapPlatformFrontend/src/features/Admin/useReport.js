import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlReport } from "endpoints";

const getReport = async () => {
  const { data } = await axios.get(urlReport);
  return data.data;
};

export default function useReport() {
  return useQuery(["profile"], () => getReport(), {
    refetchOnWindowFocus: false,
    select: (report) => {
      return {
        overallSuccessRate: report.overallSuccessRate?.toFixed(2) + "%",
        selectionSuccessRate: report.selectionSuccessRate.map((r) => {
          return {
            id: r.id,
            selectionName: r.selectionName,
            programName: r.programName,
            successRate: r.successRate?.toFixed(2) + "%",
          };
        }),
      };
    },
  });
}
