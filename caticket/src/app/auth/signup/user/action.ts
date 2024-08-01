"use server";

import { redirect } from "next/navigation";
import { z } from "zod";
import { ValidationErrorTypes } from "@/models/validation-error-types";
import { BaseServerResponse } from "@/models/base-response";

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

  if (res.success) {
    console.log(res.data);
    //call api - password should be encrypted with RSA key
    const dto = JSON.stringify({
      email: res.data.email,
      name: res.data.name,
      password: res.data.password,
      confirmPassword: res.data.confirmPassword,
    });

    const response = await fetch("http://localhost:5001/register/user", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: dto,
    });

    const data: BaseServerResponse = await response.json();

    console.log(data);

    // const token = await new SignJWT({
    //   email: res.data.email,
    //   name: res.data.name,
    //   roles: ["user"],
    // })
    //   .setProtectedHeader({ alg: "HS256" })
    //   .setIssuedAt()
    //   .sign(key);

    // cookies().set("token", token);
    if (response.ok) {
      redirect("/auth/login");
    } else {
      return { errors: { server: data.errors } };
    }
  } else {
    return { errors: { zod: res.error.issues } };
  }
}
