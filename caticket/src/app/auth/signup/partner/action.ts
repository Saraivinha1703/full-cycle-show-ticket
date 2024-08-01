"use server";

import { BASE_SALESAPI_URL } from "@/consts/sales-app";
import { BaseServerResponse } from "@/models/base-response";
import { ValidationErrorTypes } from "@/models/validation-error-types";
import { redirect } from "next/navigation";
import { z } from "zod";

const schema = z
  .object({
    name: z.string().min(1, "Please insert the company name."),
    email: z
      .string({ required_error: "Please insert the company's email." })
      .email("Invalid email."),
    password: z
      .string({ required_error: "A password is required." })
      .min(8, "The password must have at least 8 characters."),
    confirmPassword: z
      .string({ required_error: "Confirm password is required." })
      .min(8, "The password must have at least 8 characters."),
  })
  .superRefine(({ confirmPassword, password }, ctx) => {
    if (confirmPassword !== password)
      ctx.addIssue({
        code: "custom",
        message: "Both passwords must match.",
        path: ["confirmPassword", "password"],
      });
  });

export async function SignUpPartner(
  prevState: any,
  formData: FormData
): Promise<{ errors: ValidationErrorTypes } | undefined> {
  const req = {
    name: formData.get("name"),
    email: formData.get("email"),
    password: formData.get("password"),
    confirmPassword: formData.get("confirmPassword"),
  };

  const res = schema.safeParse(req);

  if (!res.success) return { errors: { zod: res.error.issues } };

  console.log(res.data);
  console.log("Sales API on: ", `${BASE_SALESAPI_URL}/register/partner`);

  const response = await fetch(`${BASE_SALESAPI_URL}/register/partner`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(req),
  });

  const data: BaseServerResponse = await response.json();

  console.log(JSON.stringify(data));

  if (!response.ok) return { errors: { server: data.errors } };

  redirect("/auth/login");
}
