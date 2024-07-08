import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function AppLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const hasToken = cookies().get("token");

  if (!hasToken) redirect("/auth/login");

  return <div className="h-[calc(100%-4rem)]">{children}</div>;
}
