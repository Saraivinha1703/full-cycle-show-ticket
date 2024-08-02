import { SpotSeat } from "@/components/spot-seat";

export function EventSeats() {
  const spots = [{ name: "A1" }];
  return (
    <div className="transition-all duration-200 flex flex-col h-fit bg-accent p-4 rounded-md w-full shadow-md shadow-black/10 hover:ring-1 hover:ring-primary sm:w-3/5">
      <span className="w-full text-lg font-semibold tracking-widest bg-muted text-center uppercase py-2 rounded-md">
        stage
      </span>
      <div className="md:w-full md:justify-normal">
        <div className="flex gap-3 items-center py-2">
          <span className="w-4">A</span>
          {spots.map((spot) => (
            <SpotSeat
              key={spot.name}
              spotId={spot.name}
              spotLabel={spot.name.slice(1)}
              selected={false}
              reserved={false}
            />
          ))}
        </div>
      </div>
      <div className="flex flex-col justify-evenly pt-2 border-t border-background/60 sm:flex-row">
        <div className="flex items-center gap-2">
          <circle className="bg-emerald-500 w-4 h-4 rounded-full" />
          <span>Available</span>
        </div>
        <div className="flex items-center gap-2">
          <circle className="bg-muted w-4 h-4 rounded-full" />
          <span>Reserved</span>
        </div>
        <div className="flex items-center gap-2">
          <circle className="bg-primary w-4 h-4 rounded-full" />
          <span>Selected</span>
        </div>
      </div>
    </div>
  );
}
