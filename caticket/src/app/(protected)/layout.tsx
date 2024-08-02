import { BASE_SALESAPI_URL } from "@/consts/sales-app";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default async function AppLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const token = cookies().get("token");

  async function validateToken(token: string): Promise<boolean> {
    const response = await fetch(`${BASE_SALESAPI_URL}/validate-user`, {
      headers: { Authorization: `Bearer ${token}` },
    });

    console.log("token validation header: ", response.status);

    if (response.status === 401) return false; //unauthorized

    return response.ok;
  }

  if (!token) redirect("/auth/login");
  if (!(await validateToken(token.value))) redirect("/auth/login");

  return <div className="flex flex-col h-full pt-16">{children}</div>;
}
