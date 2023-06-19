import create from "zustand";
import { devtools } from "zustand/middleware";

const initialState = {
  showModal: false,

  page: 1,
  totalPages: 1,
  pageSize: 5,
  sort: "",
  filter: "",
  value: "",

  querySelections: "",
  queryStudents: "",

  items: [],
};

let store = (set) => ({
  ...initialState,
  setShowModal: (show) => set(() => ({ showModal: show })),

  setPage: (page) => set(() => ({ page })),
  setTotalPages: (totalPages) => set(() => ({ totalPages })),
  setPageSize: (pageSize) => set(() => ({ pageSize })),
  setSort: (sort) => set(() => ({ sort })),
  setFilter: (filter) => set(() => ({ filter })),
  setValue: (value) => set(() => ({ value })),

  setQuerySelections: (query) => set(() => ({ query })),
  setQueryStudents: (query) => set(() => ({ query })),

  setItems: (items) => set(() => ({ items })),

  reset: () => set(initialState),
});

store = devtools(store);

export const useStore = create(store);
