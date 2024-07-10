import Image from "next/image";
import { Button } from "../ui/button";
import { Logout } from "@/lib/actions";
import { cookies } from "next/headers";
import { ThemeSwitcher } from "../theme-switcher";
import Link from "next/link";
import { redirect } from "next/navigation";

export function Navbar() {
  const token = cookies().get("token");

  async function navigateToLogIn() {
    "use server";
    redirect("/auth/login")
  }

  return (
    <nav className="h-16 p-4 border-b border-input w-full flex justify-between fixed top-0">
      <Link href="/" className="flex gap-2 h-full justify-center items-center">
        <Image alt="logo" src="/logo.ico" width={35} height={28} />
        <h1 className="text-3xl font-light tracking-wide">Caticket</h1>
      </Link>
      <div className="flex gap-2">
        {token === undefined ? (
          <form action={navigateToLogIn}>
            <Button type="submit" variant="ghost">
              Log In
            </Button>
          </form>
          ) : (
          <form action={Logout}>
            <Button type="submit" variant="ghost">
              Logout
            </Button>
          </form>
        )}
        <ThemeSwitcher />
      </div>
    </nav>
  );
}
