import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { urlStudents } from "endpoints";

const addStudent = async (newStudent) => {
  const { data } = await axios.post(urlStudents, newStudent);
  return data;
};

export default function useNewStudent() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  return useMutation(addStudent, {
    onSuccess: () => {
      queryClient.invalidateQueries(["students"]);
      navigate("/students");
    },
  });
}
