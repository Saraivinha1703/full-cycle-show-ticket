import Image from "next/image";
import Link from "next/link";

type ShowCardProps = {
  eventId: string;
  date: Date;
  image: {
    alt: string;
    src: string;
  };
  title: string;
  location: string;
};

export function ShowCard({
  eventId,
  date,
  image,
  location,
  title,
}: ShowCardProps) {
  return (
    <Link href={`/events/${eventId}/spots`}>
      <div className="flex flex-col rounded-2xl bg-accent">
        <Image alt={image.alt} src={image.src} width={300} height={260} />
        <div className="flex flex-col gap-y-2 px-4 py-6">
          <p className="text-sm uppercase">
            {date.toLocaleDateString("en-US", {
              weekday: "long",
              day: "2-digit",
              month: "2-digit",
              year: "numeric",
            })}
          </p>
          <p className="font-semibold tracking-wider">{title}</p>
          <p className="text-sm font-normal">{location}</p>
        </div>
      </div>
    </Link>
  );
}
