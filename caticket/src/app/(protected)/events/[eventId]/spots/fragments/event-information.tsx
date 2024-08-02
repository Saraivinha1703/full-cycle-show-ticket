export function EventInformation() {
  return (
    <div className="transition-all duration-200 flex flex-col gap-4 rounded-md bg-accent p-4 shadow-md shadow-black/10 hover:ring-1 hover:ring-primary">
      <span className="text-primary font-semibold tracking-wider text-sm">
        MONDAY, 01/01/2024
      </span>
      <div className="flex flex-col gap-1">
        <h1 className="font-bold tracking-widest text-2xl">Show</h1>
        <span className="text-sm font-light text-foreground/60">Lisbon</span>
      </div>
      <div className="flex flex-col gap-6 sm:flex-row sm:gap-20">
        <div className="flex flex-col gap-2">
          <span className="font-semibold">Organization</span>
          <span className="text-foreground/60">a</span>
        </div>
        <div className="flex flex-col gap-2">
          <span className="font-semibold">Classification</span>
          <span className="text-foreground/60">a</span>
        </div>
      </div>
    </div>
  );
}
