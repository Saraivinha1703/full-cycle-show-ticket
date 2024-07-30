import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function AppLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const hasToken = cookies().get("token");

  if (!hasToken) redirect("/auth/login");

  return <div className="flex flex-col h-full pt-16">{children}</div>;
}
