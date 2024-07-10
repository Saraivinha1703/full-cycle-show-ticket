"use server";

import { cookies } from "next/headers";
import { redirect } from "next/navigation";
import { z, ZodIssue } from "zod";
import { SignJWT } from "jose";

const schema = z.object({
  name: z.string({required_error: "Please insert your name."}),
  email: z.string({required_error: "Please insert your email."}).email("Invalid email."),
  password: z.string({required_error: "A password is required."}).min(8, "The password must have at least 8 characters."),
  confirmPassword: z.string({required_error: "Confirm password is required."}).min(8, "The password must have at least 8 characters."),
}).superRefine(({confirmPassword, password}, ctx) => {
  if(confirmPassword !== password) ctx.addIssue({code: "custom", message: "Both passwords must match.", path: ["confirmPassword", "password"]})
});

const key = new TextEncoder().encode("secret");

export async function SignUpUser(
  prevState: any,
  formData: FormData
): Promise<{ errors: ZodIssue[] }> {
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
      roles: ["user"],
    });

    // const token = await new SignJWT({
    //   email: res.data.email,
    //   name: res.data.name,
    //   roles: ["user"],
    // })
    //   .setProtectedHeader({ alg: "HS256" })
    //   .setIssuedAt()
    //   .sign(key);

    // cookies().set("token", token);
    
    redirect("/auth/login");
  } else {
    return { errors: res.error.issues };
  }
}
