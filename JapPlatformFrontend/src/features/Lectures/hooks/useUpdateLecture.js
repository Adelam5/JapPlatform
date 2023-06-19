import { useNavigate } from "react-router-dom";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlLectures } from "endpoints";

const updateLecture = async (lecture) => {
  const { data } = await axios.put(`${urlLectures}/${lecture.id}`, lecture);
  return data;
};

export default function useUpdateLecture() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(updateLecture, {
    onSuccess: () => {
      queryClient.invalidateQueries("lectures");
      navigate("/lectures");
    },
  });
}
