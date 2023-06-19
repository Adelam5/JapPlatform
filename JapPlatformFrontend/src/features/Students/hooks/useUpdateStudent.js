import { useNavigate } from "react-router-dom";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlStudents } from "endpoints";

const updateStudent = async (student) => {
  const { data } = await axios.put(`${urlStudents}/${student.id}`, student);
  return data;
};

export default function useUpdateStudent() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(updateStudent, {
    onSuccess: (data) => {
      queryClient.invalidateQueries("students");
      navigate("/students");
    },
  });
}
