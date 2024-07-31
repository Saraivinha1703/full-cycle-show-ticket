"use server";

import { redirect } from "next/navigation";
import { z, ZodIssue } from "zod";

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

const key = new TextEncoder().encode("secret");

export async function SignUpPartner(
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
    const response = await fetch("http://localhost:5000/register/partner", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(req),
    });

    const data = await response.json();

    console.log(data);
    // const token = await new SignJWT({
    //   email: res.data.email,
    //   name: res.data.name,
    //   roles: ["partner"],
    // })
    //   .setProtectedHeader({ alg: "HS256" })
    //   .setIssuedAt()
    //   .sign(key);

    //cookies().set("token", token);
    redirect("/auth/login");
  } else {
    return { errors: res.error.issues };
  }
}
