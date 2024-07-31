import { IoCartOutline } from "react-icons/io5";

export function Billing() {
  return (
    <div className="flex flex-col flex-1 gap-8 p-4 rounded-lg bg-accent h-fit sm:p-8">
      <div className="flex gap-2 items-center">
        <h1 className="text-2xl font-semibold tracking-wider">Your cart</h1>
        <IoCartOutline className="w-6 h-6" />
      </div>

      <div className="flex flex-col gap-5 px-4">
        <div className="flex flex-col gap-2 border-2 border-dashed border-foreground/40 p-2 rounded-sm">
          <h2 className="font-semibold text-lg">Show</h2>
          <span className="text-foreground/60">Location</span>
          <span className="text-foreground/60">Date</span>
        </div>

        <div className="flex flex-col gap-2 border-2 border-dashed border-foreground/40 p-2 rounded-sm">
          <h2 className="font-semibold text-lg">Show</h2>
          <span className="text-foreground/60">Location</span>
          <span className="text-foreground/60">Date</span>
        </div>
      </div>

      <h3 className="text-lg font-semibold tracking-wider">
        Final price: € 30,00
      </h3>
    </div>
  );
}
