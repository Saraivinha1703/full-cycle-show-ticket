"use client";

import { Button } from "@/components/ui/button";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";

type AddEventsProps = {
    tenantId: string;
}

export function AddEvents({tenantId}: AddEventsProps) {
    return (
        <Dialog>
            <DialogTrigger asChild>
                <Button>Add Event</Button>
            </DialogTrigger>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Add Event</DialogTitle>
                </DialogHeader>
                <form className="flex flex-col gap-4">
                    <Input placeholder="Name" />
                    <div className="flex gap-3">
                        <Input placeholder="Rating" />
                        <Input placeholder="Location" />
                    </div>
                    <Input placeholder="Organization" />
                    <Input placeholder="Image URL" />
                    <div className="flex gap-3">
                        <Input placeholder="Price" />
                        <Input placeholder="Capacity" />
                    </div>
                    <Input placeholder="Date" />
                    <Input placeholder="Description" />
                    <div className="flex justify-between">
                        <Button variant="outline" type="reset">Clean</Button>
                        <Button type="submit">Submit</Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}