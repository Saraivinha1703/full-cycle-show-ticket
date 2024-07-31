type SpotSeatProps = {
  spotId: string;
  spotLabel: string;
  reserved: boolean;
  selected: boolean;
};

export function SpotSeat({
  spotId,
  spotLabel,
  reserved,
  selected,
}: SpotSeatProps) {
  return (
    <div className="flex">
      <input
        type="checkbox"
        name="spot"
        id={`spot-${spotId}`}
        className="peer hidden"
        value={spotId}
        disabled={reserved}
        defaultChecked={selected}
      />
      <label
        htmlFor={`spot-${spotId}`}
        className="transition-all duration-300 h-6 w-6 cursor-pointer select-none rounded-sm bg-emerald-500 text-center peer-checked:bg-primary peer-disabled:cursor-not-allowed peer-disabled:bg-muted"
      >
        {spotLabel}
      </label>
    </div>
  );
}
