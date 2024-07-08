"use server";

import { cookies } from "next/headers";
import { redirect } from "next/navigation";
import { z, ZodIssue } from "zod";

const schema = z.object({
  email: z.string().email("Invalid email"),
  password: z.string().min(8, "The password must have at least 8 characters"),
});

export async function Login(
  prevState: any,
  formData: FormData
): Promise<{ errors: ZodIssue[] }> {
  const req = {
    email: formData.get("email"),
    password: formData.get("password"),
  };

  const res = schema.safeParse(req);

  if (res.success) {
    console.log(res.data);
    cookies().set("isLoggedIn", "true");
    redirect("/dashboard");
  } else {
    return { errors: res.error.issues };
  }
}
