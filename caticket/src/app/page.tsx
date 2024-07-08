import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function Home() {
  const isLogged = cookies().get("isLoggedIn");

  if (!isLogged) redirect("/auth/login");

  return (
    <main className="flex min-h-screen flex-col">
      <p>Hello World!</p>
    </main>
  );
}
