import * as Yup from "yup";

export const lectureSchema = Yup.object({
  name: Yup.string().required("Name is required"),
});

export const lectureUpdateSchema = Yup.object({
  name: Yup.string().required("Name is required"),
});
