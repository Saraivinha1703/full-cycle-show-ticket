import { ShowCard } from "@/components/show-card";
import { BASE_SALESAPI_URL } from "@/consts/sales-app";
import { EventModel } from "@/models/event-model";

type UserEventsProps = {
  token: string;
};

export async function UserEvents({ token }: UserEventsProps) {
  const response = await fetch(`${BASE_SALESAPI_URL}/events`, {
    method: "GET",
    headers: { Authorization: `Bearer ${token}` },
  });

  const data: EventModel[] = await response.json();

  return (
    <main className="min-h-[calc(100vh-4rem)] p-4">
      <h1 className="text-2xl font-semibold tracking-wide">Events available</h1>
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
            <span>No events available yet. :(</span>
          </div>
        )}
      </div>
    </main>
  );
}
