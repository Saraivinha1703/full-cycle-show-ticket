"use server";

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

  if (res.success) {
    console.log(res.data);
    //call api - password should be encrypted with RSA key
    const response = await fetch("http://localhost:5001/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(req),
    });

    const data: ServerResponse = await response.json();

    // const token = await new SignJWT({
    //   email: res.data.email,
    //   name: "test",
    //   roles: ["user"],
    // })
    //   .setProtectedHeader({ alg: "HS256" })
    //   .setIssuedAt()
    //   .sign(key);
    if (response.ok && data.token) {
      cookies().set("token", data.token);
      redirect("/events");
    } else {
      return { errors: { server: data.errors } };
    }
  } else {
    return { errors: { zod: res.error.issues } };
  }
}
