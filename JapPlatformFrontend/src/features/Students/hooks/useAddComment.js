import { useNavigate } from "react-router-dom";
import axios from "axios";
import { useMutation, useQueryClient } from "@tanstack/react-query";

import { urlStudents } from "endpoints";

const addComment = async (newComment) => {
  const { data } = await axios.put(`${urlStudents}/AddComment`, newComment);
  return data;
};

export default function useAddComment() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(addComment, {
    onSuccess: (data) => {
      queryClient.invalidateQueries("student");
      navigate(`/students/${data.data.id}`);
    },
  });
}
