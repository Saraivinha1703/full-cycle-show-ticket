"use server";

import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export async function Logout() {
  cookies().delete("token");
  redirect("/auth/login");
}