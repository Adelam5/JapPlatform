import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import dayjs from "dayjs";

import { urlPrograms } from "endpoints";
import { useStore } from "store";

const getProgram = async (programId) => {
  const { data } = await axios.get(`${urlPrograms}/${programId}`);
  return data.data;
};

export default function useProgram(programId) {
  const setItems = useStore((state) => state.setItems);
  return useQuery(["programs", programId], () => getProgram(programId), {
    refetchOnWindowFocus: false,
    onSuccess: (program) => {
      setItems(
        program?.items.map((i) => {
          return {
            itemId: i.id,
            orderNumber: i.orderNumber,
          };
        })
      );
    },
    select: (program) => {
      return {
        id: program.id,
        name: program.name,
        description: program.description,
        createdAt: dayjs(program.createdAt).format("DD/MM/YYYY"),
        modifiedAt: dayjs(program.modifiedAt).format("DD/MM/YYYY"),
        items: program.items.map((i) => {
          return {
            id: i.item.id,
            orderNumber: i.orderNumber,
            name: i.item.name,
            description: i.item.description,
            discriminator: i.item.discriminator,
            workHours: i.item.workHours,
            urls: i.item.urls,
          };
        }),
      };
    },
  });
}
