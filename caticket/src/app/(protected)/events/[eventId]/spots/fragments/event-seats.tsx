export function EventSeats() {
  const spots = [{ name: "A1" }];
  return (
    <div className="flex flex-col bg-accent p-4 rounded-md w-3/5">
      <span className="w-full text-lg font-semibold tracking-widest bg-background/60 text-center uppercase py-2 rounded-md">
        stage
      </span>
      <div className="flex justify-evenly">
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
