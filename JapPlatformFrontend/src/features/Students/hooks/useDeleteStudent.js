import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { urlStudents } from "endpoints";

const deleteStudent = async (studentId) => {
  const { data } = await axios.delete(`${urlStudents}/${studentId}`);
  return data;
};

export default function useDeleteStudent() {
  const queryClient = useQueryClient();
  return useMutation(deleteStudent, {
    onSuccess: () => {
      queryClient.invalidateQueries(["students"]);
    },
  });
}
