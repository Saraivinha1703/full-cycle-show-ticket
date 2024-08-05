"use server";

import { JwtPayload } from "@/models/jwt-payload";

export async function getJwtTokenPayload(token: string) {
  const base64Payload = token.split(".")[1];
  const payload = Buffer.from(base64Payload, "base64");
  return JSON.parse(payload.toString()) as JwtPayload;
}
