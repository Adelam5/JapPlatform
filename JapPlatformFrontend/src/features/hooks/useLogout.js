import { useNavigate } from "react-router-dom";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

import { urlLogout } from "endpoints";

const logout = async () => {
  const { data } = await axios.get(`${urlLogout}`);
  return data.data;
};

export const useLogout = () => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  return useQuery(["logout"], logout, {
    enabled: false,
    onSuccess: () => {
      queryClient.removeQueries();
      navigate("/");
    },
  });
};
