import { ShowCard } from "@/components/show-card";
import { EventModel } from "@/models/event-model";

export default function DashboardPage() {
  const events: EventModel[] = [
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
    {
      id: "1",
      date: "2024-01-01T10:00:00Z",
      image_url: "",
      location: "Lisbon, Portugal",
      name: "Queen Show",
      organization: "a",
      price: 30,
      rating: "G",
    },
  ];

  return (
    <main className="p-4">
      <h1>Events available</h1>
      <div className="flex flex-wrap justify-center gap-12">
        {events.map((e) => (
          <ShowCard
            key={e.id}
            eventId={e.id}
            date={new Date(e.date)}
            image={{ alt: e.name, src: e.image_url }}
            location={e.location}
            title={e.name}
          />
        ))}
      </div>
    </main>
  );
}
