"use server";

import { BASE_SALESAPI_URL } from "@/consts/sales-app";
import { BaseServerResponse } from "@/models/base-response";
import { ValidationErrorTypes } from "@/models/validation-error-types";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";
import { z } from "zod";

type ServerResponse = BaseServerResponse & {
  token?: string;
};

const schema = z.object({
  email: z.string().email("Invalid email"),
  password: z.string().min(8, "The password must have at least 8 characters"),
});

export async function Login(
  prevState: any,
  formData: FormData
): Promise<{ errors: ValidationErrorTypes } | undefined> {
  const req = {
    email: formData.get("email"),
    password: formData.get("password"),
  };

  const res = schema.safeParse(req);

  if (!res.success) return { errors: { zod: res.error.issues } };

  console.log(res.data);

  const response = await fetch(`${BASE_SALESAPI_URL}/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(req),
  });

  const data: ServerResponse = await response.json();

  if (!response.ok || !data.token) return { errors: { server: data.errors } };

  cookies().set("token", data.token);
  redirect("/events");
}
