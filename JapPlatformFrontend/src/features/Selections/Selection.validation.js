import * as Yup from "yup";

export const selectionSchema = Yup.object({
  name: Yup.string().required("Name is required"),
  programId: Yup.number()
    .required("Program is required")
    .typeError("Program is required")
    .positive(1, "Program Id must be positive number"),
  studentId: Yup.number()
    .required("Student is required")
    .typeError("Student is required")
    .positive(1, "Student Id must be positive number"),
  startDate: Yup.date().required("Start date is required"),
  status: Yup.mixed()
    .required("Status is required")
    .oneOf(["Active", "Complete"], "Status must be: Active, Complete"),
});

export const selectionUpdateSchema = Yup.object({
  name: Yup.string().required("Name is required"),
  programId: Yup.number()
    .required("Program is required")
    .typeError("Program is required")
    .positive(1, "Program Id must be positive number"),
  startDate: Yup.date().required("Start date is required"),
  status: Yup.mixed()
    .required("Status is required")
    .oneOf(["Active", "Complete"], "Status must be: Active, Complete"),
});

export const commentSchema = Yup.object({
  text: Yup.string().required("Text is required"),
});
