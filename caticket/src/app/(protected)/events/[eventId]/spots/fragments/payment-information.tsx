export function PaymentInformation() {
  return (
    <div className="flex flex-col gap-8">
      <h2 className="text-xl font-semibold tracking-wide">
        Check the event prices
      </h2>
      <div className="flex flex-col gap-2">
        <span>Full: {"€ 30,00"}</span>
        <span>Half: {"€ 15,00"}</span>
      </div>
    </div>
  );
}
