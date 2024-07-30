export function PaymentInformation() {
  return (
    <div className="transition-all duration-200 flex flex-col gap-8 bg-accent w-2/5 p-4 rounded-md shadow-md shadow-black/10 hover:ring-1 hover:ring-primary">
      <h2 className="text-xl font-semibold tracking-wide">
        Check the event prices
      </h2>
      <div className="flex flex-col gap-2">
        <span>Full: <b className="text-lg">{"€ 30,00"}</b></span>
        <span>Half: <b className="text-lg">{"€ 15,00"}</b></span>
      </div>
    </div>
  );
}
