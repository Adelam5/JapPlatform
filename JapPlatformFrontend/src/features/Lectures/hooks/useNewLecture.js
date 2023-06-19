import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import axios from "axios";

import { urlLectures } from "endpoints";

const addLecture = async (newLecture) => {
  const { data } = await axios.post(urlLectures, newLecture);
  return data;
};

export default function useNewLecture() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(addLecture, {
    onSuccess: () => {
      queryClient.invalidateQueries(["lectures"]);
      navigate("/lectures");
    },
  });
}
