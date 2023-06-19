import { useNavigate } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";

import { urlUser } from "endpoints";

const getUser = async () => {
  const { data } = await axios.get(urlUser);
  return data.data;
};

export const useCurrentUser = () => {
  const navigate = useNavigate();
  return useQuery(["user"], getUser, {
    refetchOnWindowFocus: false,
    refetchOnMount: false,
    retry: 0,
    onError: () => {
      navigate("/");
    },
  });
};
