import { Button } from "@/components/ui/button";
import { Radio } from "@/components/ui/radio";
import Link from "next/link";

export function PaymentInformation() {
  return (
    <div className="transition-all duration-200 flex flex-col gap-8 bg-accent w-full p-4 rounded-md shadow-md shadow-black/10 hover:ring-1 hover:ring-primary sm:w-2/5">
      <h2 className="text-xl font-semibold tracking-wide">
        Check the event prices
      </h2>

      <div className="flex flex-col gap-2">
        <span className="text-foreground/90">Full: {"€ 30,00"}</span>
        <span className="text-foreground/90">Half: {"€ 15,00"}</span>
      </div>

      <div className="flex gap-8">
        <div className="flex items-center gap-2">
          <Radio
            value="full"
            id="ticket-full"
            name="group"
            label={{ value: "Full" }}
          />
        </div>
        <div className="flex items-center gap-2">
          <Radio
            value="half"
            id="ticket-half"
            name="group"
            label={{ value: "Half" }}
          />
        </div>
      </div>
      <div>
        <span>Total: € 30,00</span>
      </div>
      <Button asChild className="uppercase tracking-wider font-semibold">
        <Link href="/checkout">Buy tickets</Link>
      </Button>
    </div>
  );
}
