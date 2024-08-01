"use server";

import { redirect } from "next/navigation";
import { z } from "zod";
import { ValidationErrorTypes } from "@/models/validation-error-types";
import { BaseServerResponse } from "@/models/base-response";
import { BASE_SALESAPI_URL } from "@/consts/sales-app";

const schema = z
  .object({
    name: z.string({ required_error: "Please insert your name." }),
    email: z
      .string({ required_error: "Please insert your email." })
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

export async function SignUpUser(
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

  const dto = JSON.stringify({
    email: res.data.email,
    name: res.data.name,
    password: res.data.password,
    confirmPassword: res.data.confirmPassword,
  });

  const response = await fetch(`${BASE_SALESAPI_URL}/register/user`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: dto,
  });

  const data: BaseServerResponse = await response.json();

  console.log(data);

  if (!response.ok) return { errors: { server: data.errors } };

  redirect("/auth/login");
}
