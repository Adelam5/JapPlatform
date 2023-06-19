import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import dayjs from "dayjs";
import { urlStudents } from "endpoints";

const getStudent = async (studentId) => {
  const { data } = await axios.get(`${urlStudents}/${studentId}`);
  return data.data;
};

export default function useStudent(studentId) {
  const queryClient = useQueryClient();
  return useQuery(["students", studentId], () => getStudent(studentId), {
    refetchOnWindowFocus: false,
    initialData: () => {
      const student = queryClient
        .getQueryData(["students", null])
        ?.find((student) => student.id == studentId); // eslint-disable-line
      if (student) {
        return student;
      } else {
        return undefined;
      }
    },
    select: (student) => {
      return {
        id: student.id,
        firstName: student.firstName,
        lastName: student.lastName,
        birthDate: dayjs(student.birthDate).format("YYYY-MM-DD"),
        selection: student?.selection,
        program: student?.selection?.program?.name,
        status: student.status,
        comments: student.comments,
      };
    },
  });
}
