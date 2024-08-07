import { z } from "zod";

export const createEventFormSchema = z.object({
  name: z.string().min(1, "The name field is required"),
  rating: z.string().min(1, "The rating field is required"),
  location: z.string().min(1, "The location field is required"),
  organization: z.string().min(1, "The organization field is required"),
  imageURL: z.string().min(1, "The image URL field is required"),
  price: z.coerce
    .number()
    .min(1, "The price field is required")
    .gt(0, "The price must be greater than 0"),
  capacity: z.coerce
    .number()
    .min(1, "The capacity field is required")
    .gt(0, "The capacity must be greater than 0"),
  date: z.coerce.date().min(new Date(Date.now()), "The date field is required"),
  description: z.string().nullable(),
});

export type EventFormSchema = z.infer<typeof createEventFormSchema>;
