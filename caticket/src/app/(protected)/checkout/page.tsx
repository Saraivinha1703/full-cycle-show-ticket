import { Billing } from "./fragments/billing";
import { CheckoutForm } from "./fragments/form";

export default function CheckoutPage() {
  return (
    <main className="min-h-[calc(100vh-4rem)]">
      <div className="flex w-full flex-col gap-5 sm:flex-row sm:gap-10 p-8">
        <Billing />
        <CheckoutForm />
      </div>
    </main>
  );
}
