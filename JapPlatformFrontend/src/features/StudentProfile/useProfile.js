import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import dayjs from "dayjs";

import { urlProfile } from "endpoints";

const getProfile = async () => {
  const { data } = await axios.get(urlProfile);
  return data.data;
};

export default function useProfile() {
  return useQuery(["profile"], () => getProfile(), {
    refetchOnWindowFocus: false,
    select: (profile) => {
      const formatedProfile = {
        ...profile,
        birthDate: dayjs(profile?.birthDate).format("DD/MM/YYYY"),
        selection: {
          ...profile?.selection,
          startDate: dayjs(profile?.selection?.startDate).format("DD/MM/YYYY"),
        },
        personalProgram: profile?.personalProgram.map((item) => {
          return {
            ...item,
            startDate: dayjs(item?.startDate).format("DD/MM/YYYY"),
            endDate: dayjs(item?.endDate).format("DD/MM/YYYY"),
            progress: item?.progress + "%",
          };
        }),
      };
      return formatedProfile;
    },
  });
}
