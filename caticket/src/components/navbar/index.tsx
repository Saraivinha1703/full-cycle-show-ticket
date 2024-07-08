import Image from "next/image";
import { Button } from "../ui/button";
import { Logout } from "@/lib/actions";
import { cookies } from "next/headers";
import { ThemeSwitcher } from "../theme-switcher";

export function Navbar() {
  const isLoggedIn = cookies().get("isLoggedIn");

  return (
    <nav className="h-16 p-4 border-b border-input w-full flex justify-between fixed top-0">
      <div className="flex gap-2 h-full justify-center items-center">
        <Image alt="logo" src="/logo.ico" width={35} height={28} />
        <h1 className="text-3xl font-light tracking-wide">Caticket</h1>
      </div>
      <div className="flex gap-2">
        {isLoggedIn && (
          <form>
            <Button formAction={Logout} variant="ghost">
              Logout
            </Button>
          </form>
        )}
        <ThemeSwitcher />
      </div>
    </nav>
  );
}
