"use client";

import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { AddEventsForm } from "./form";
import { EventFormSchema } from "./form-schema";
import { BASE_SALESAPI_URL } from "@/consts/sales-app";
import { useState } from "react";
import { useRouter } from "next/navigation";

type AddEventsProps = {
  token: string;
};

export function AddEvents({ token }: AddEventsProps) {
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const router = useRouter();

  async function createEvent(data: EventFormSchema, reset: () => void) {
    const req = {
      ...data,
      date: data.date.toISOString().split(".")[0],
      description: data.description === "" ? undefined : data.description,
    };

    console.log(req);

    const response = await fetch(`${BASE_SALESAPI_URL}/events`, {
      method: "POST",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      },
      body: JSON.stringify(req),
    });

    if (response.status === 200) {
      reset();
      setIsDialogOpen(false);
      router.refresh();
    }
  }

  return (
    <Dialog open={isDialogOpen} onOpenChange={(val) => setIsDialogOpen(val)}>
      <DialogTrigger asChild>
        <Button>Add Event</Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Add Event</DialogTitle>
        </DialogHeader>
        <AddEventsForm createEvent={createEvent} />
      </DialogContent>
    </Dialog>
  );
}
