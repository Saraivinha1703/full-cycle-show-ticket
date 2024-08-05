import { getJwtTokenPayload } from "@/lib/session";
import { cookies } from "next/headers";
import { PartnerEvents } from "./fragments/partner-events";
import { UserEvents } from "./fragments/user-events";

export default async function EventsPage() {
  const token = cookies().get("token")!.value;

  const payload = getJwtTokenPayload(token);

  return payload.role === "partner" ? (
    <PartnerEvents token={token} />
  ) : (
    <UserEvents token={token} />
  );
}
