import { useEffect } from "react";

import { useStore } from "store";

export default function useData(hook) {
  const filter = useStore((state) => state.filter);
  const value = useStore((state) => state.value);
  const sort = useStore((state) => state.sort);
  const page = useStore((state) => state.page);
  const pageSize = useStore((state) => state.pageSize);
  const reset = useStore((state) => state.reset);

  const { data } = hook(
    `?filter=${filter}&value=${value}&sort=${sort}&page=${page}&pageSize=${pageSize}`
  );

  useEffect(() => {
    return () => {
      reset();
    };
    //eslint-disable-next-line
  }, []);

  return data;
}
