import * as Yup from "yup";

export const studentSchema = Yup.object({
  firstName: Yup.string().required("First name is required"),
  lastName: Yup.string().required("Last name is required"),
  birthDate: Yup.date()
    .required("Birth date is required")
    .max(new Date(), "Birth date must be in the past"),
  /*   selectionId: Yup.number()
    .typeError("Selection Id must be a number")
    .positive(1, "Selection Id must be positive number"), */
  status: Yup.mixed()
    .required("Status is required")
    .oneOf(
      ["InProgram", "Success", "Failed", "Extended"],
      "Status must be: InProgram, Success, Failed or Extended"
    ),
});

export const commentSchema = Yup.object({
  text: Yup.string().required("Text is required"),
});
