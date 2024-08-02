import { Button } from "@/components/ui/button";
import { redirect } from "next/navigation";

export default function HomePage() {
  async function navigateToPartner() {
    "use server";
    redirect("/auth/signup/partner");
  }

  async function navigateToUser() {
    "use server";
    redirect("/auth/signup/user");
  }

  return (
    <main className="flex min-h-screen flex-col">
      <div className="w-full flex flex-col items-center justify-center p-24 border-b border-input">
        <h1 className="text-5xl tracking-wider text-transparent bg-gradient-to-tr from-primary to-secondary bg-clip-text font-bold font-poiret-one sm:text-7xl">
          Caticket
        </h1>
        <h2 className="text-2xl tracking-wider text-transparent bg-gradient-to-tr from-primary to-secondary bg-clip-text font-monoton opacity-60 sm:text-4xl">
          THE BEST SELLING TICKET PLATFORM!
        </h2>
      </div>
      <div className="flex flex-col gap-6 p-4">
        <div className="flex gap-2 items-center">
          <p>
            Are you interested in selling tickets for shows at your festival? Be
            our partner and sell your tickets!
          </p>
          <form action={navigateToPartner}>
            <Button type="submit" variant="outline" size="sm">
              Sign and Sell
            </Button>
          </form>
        </div>
        <div className="flex gap-2 items-center">
          <p>
            Or maybe you are interested in buying tickets for shows at some
            festival, right? Sign up and buy the tickets that you want!
          </p>
          <form action={navigateToUser}>
            <Button type="submit" variant="outline" size="sm">
              Sign and Buy
            </Button>
          </form>
        </div>
      </div>
    </main>
  );
}
