import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlLectures } from "endpoints";

const deleteLecture = async (lectureId) => {
  const { data } = await axios.delete(`${urlLectures}/${lectureId}`);
  return data;
};

export default function useDeleteLecture() {
  const queryClient = useQueryClient();
  return useMutation(deleteLecture, {
    onSuccess: () => {
      queryClient.invalidateQueries(["lectures"]);
    },
  });
}
