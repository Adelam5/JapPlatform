import { useNavigate } from "react-router-dom";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlLogin } from "endpoints";

const login = async (user) => {
  const { data } = await axios.post(urlLogin, user);
  return data;
};

export const useLogin = () => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  return useMutation(login, {
    retry: 0,
    onSuccess: (data) => {
      queryClient.invalidateQueries("user");
      if (data.data.role === "Admin") {
        navigate("/dashboard");
      } else {
        navigate("/profile");
      }
    },
  });
};
