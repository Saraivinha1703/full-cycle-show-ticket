import { EventModel } from "@/models/event-model";
import { SpotModel } from "@/models/spot-model";
import { EventInformation } from "./fragments/event-information";
import { EventSeats } from "./fragments/event-seats";
import { PaymentInformation } from "./fragments/payment-information";

export default function SpotPage() {
  const event: EventModel = {
    id: "1",
    date: "2024-01-01T10:00:00Z",
    image_url: "",
    location: "Lisbon, Portugal",
    name: "Queen Show",
    organization: "a",
    price: 30,
    rating: "G",
  };

  const spot: SpotModel[] = [
    {
      id: "1",
      name: "A1",
      status: "available",
    },
    {
      id: "2",
      name: "A2",
      status: "available",
    },
    {
      id: "3",
      name: "B1",
      status: "available",
    },
    {
      id: "4",
      name: "B2",
      status: "available",
    },
  ];

  return (
    <main className="flex flex-col gap-10 p-8">
      <EventInformation />

      <div className="flex flex-col gap-2">
        <h1 className="text-xl font-semibold">Select your seat</h1>
        <div className="flex gap-2">
          <EventSeats />
          <PaymentInformation />
        </div>
      </div>
    </main>
  );
}
