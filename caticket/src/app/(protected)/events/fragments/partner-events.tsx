import { Button } from "@/components/ui/button";
import { BASE_SALESAPI_URL } from "@/consts/sales-app";

type PartnerEventsProps = {
  token: string;
};

export async function PartnerEvents({ token }: PartnerEventsProps) {
  const response = await fetch(`${BASE_SALESAPI_URL}/events`, {
    method: "GET",
    headers: { Authorization: `Bearer ${token}` },
  });

  const data = response.bodyUsed ? await response.json() : undefined;

  return (
    <main className="min-h-[calc(100vh-4rem)] p-4">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-semibold">Your events</h1>
        <Button>Add Event</Button>
      </div>
      {JSON.stringify(data)}
    </main>
  );
}
