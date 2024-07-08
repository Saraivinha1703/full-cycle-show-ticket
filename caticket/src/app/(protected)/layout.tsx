import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function AppLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const isLogged = cookies().get("isLoggedIn");

  if (!isLogged) redirect("/auth/login");

  return <div>{children}</div>;
}
