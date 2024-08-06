import { ShowCard } from "@/components/show-card";
import { Button } from "@/components/ui/button";
import { BASE_SALESAPI_URL } from "@/consts/sales-app";
import { EventModel } from "@/models/event-model";

type PartnerEventsProps = {
  token: string;
};

export async function PartnerEvents({ token }: PartnerEventsProps) {
  const response = await fetch(`${BASE_SALESAPI_URL}/events`, {
    method: "GET",
    headers: { Authorization: `Bearer ${token}` },
  });

  const data: EventModel[] = await response.json();

  return (
    <main className="min-h-[calc(100vh-4rem)] p-4">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-semibold">Your events</h1>
        <Button>Add Event</Button>
      </div>
      {JSON.stringify(data)}
      <div className="flex flex-wrap justify-center gap-12">
        {data.length > 0 ? (
          data.map((e) => (
            <ShowCard
              key={e.id}
              eventId={e.id}
              date={new Date(e.date)}
              image={{ alt: e.name, src: /*e.imageURL*/ "" }}
              location={e.location}
              title={e.name}
            />
          ))
        ) : (
          <div>
            <span>You didn&apos;t create any events yet. :(</span>
          </div>
        )}
      </div>
    </main>
  );
}
