"use client";

import { Button } from "@/components/ui/button";
import { Form, FormField } from "@/components/ui/form";
import { Input } from "@/components/ui/input";

import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { createEventFormSchema, EventFormSchema } from "./form-schema";
import { cn } from "@/lib/utils";

type AddEventsFormProps = {
  createEvent: (data: EventFormSchema, resetCallback: () => void) => void;
};

export function AddEventsForm({ createEvent }: AddEventsFormProps) {
  const form = useForm<EventFormSchema>({
    resolver: zodResolver(createEventFormSchema),
  });
  return (
    <Form {...form}>
      <form
        className="flex flex-col gap-4"
        onSubmit={form.handleSubmit((data) => createEvent(data, form.reset))}
      >
        <FormField
          name="name"
          control={form.control}
          defaultValue=""
          render={({
            field: { value, onChange, disabled },
            fieldState: { error },
          }) => (
            <label className="flex flex-col gap-1">
              <span className={cn("text-sm", error && "text-destructive")}>
                Name <b className="text-primary">*</b>
              </span>
              <Input
                placeholder="What is the shows name?"
                className={cn(error && "text-destructive border-destructive")}
                onChange={onChange}
                value={value}
                disabled={disabled}
              />
              {error && (
                <span className="text-sm text-destructive">
                  {error.message}
                </span>
              )}
            </label>
          )}
        />
        <div className="flex gap-3">
          <FormField
            name="rating"
            control={form.control}
            defaultValue=""
            render={({
              field: { value, onChange, disabled },
              fieldState: { error },
            }) => (
              <label className="flex flex-col flex-1 gap-1">
                <span className="text-sm">
                  Rating <b className="text-primary">*</b>
                </span>
                <Select
                  onValueChange={onChange}
                  value={value}
                  disabled={disabled}
                >
                  <SelectTrigger
                    className={cn(
                      error && "text-destructive border-destructive"
                    )}
                  >
                    <SelectValue placeholder="Select a rating option" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectGroup>
                      <SelectItem value="G">
                        G{" "}
                        <small className="text-foreground/50">
                          (General Audience)
                        </small>
                      </SelectItem>
                      <SelectItem value="PG">
                        PG{" "}
                        <small className="text-foreground/50">
                          (Parental Guidance Suggested)
                        </small>
                      </SelectItem>
                      <SelectItem value="PG-13">
                        PG-13{" "}
                        <small className="text-foreground/50">
                          (Parents Strongly Cautioned)
                        </small>
                      </SelectItem>
                      <SelectItem value="R">
                        R{" "}
                        <small className="text-foreground/50">
                          (Restricted)
                        </small>
                      </SelectItem>
                      <SelectItem value="NC-17">
                        NC-17{" "}
                        <small className="text-foreground/50">
                          (Adults Only)
                        </small>
                      </SelectItem>
                    </SelectGroup>
                  </SelectContent>
                </Select>
                {error && (
                  <span className="text-sm text-destructive">
                    {error.message}
                  </span>
                )}
              </label>
            )}
          />
          <FormField
            name="location"
            control={form.control}
            defaultValue=""
            render={({
              field: { value, onChange, disabled },
              fieldState: { error },
            }) => (
              <label className="flex flex-col gap-1">
                <span className={cn("text-sm", error && "text-destructive")}>
                  Location <b className="text-primary">*</b>
                </span>
                <Input
                  placeholder="Where is the show going to be?"
                  value={value}
                  className={cn(error && "text-destructive border-destructive")}
                  onChange={onChange}
                  disabled={disabled}
                />
                {error && (
                  <span className="text-sm text-destructive">
                    {error.message}
                  </span>
                )}
              </label>
            )}
          />
        </div>
        <FormField
          name="organization"
          control={form.control}
          defaultValue=""
          render={({
            field: { value, onChange, disabled },
            fieldState: { error },
          }) => (
            <label className="flex flex-col gap-1">
              <span className={cn("text-sm", error && "text-destructive")}>
                Organization <b className="text-primary">*</b>
              </span>
              <Input
                placeholder="Who is promoting this show?"
                className={cn(error && "text-destructive border-destructive")}
                value={value}
                disabled={disabled}
                onChange={onChange}
              />
              {error && (
                <span className="text-sm text-destructive">
                  {error.message}
                </span>
              )}
            </label>
          )}
        />
        <FormField
          name="imageURL"
          control={form.control}
          defaultValue=""
          render={({
            field: { value, onChange, disabled },
            fieldState: { error },
          }) => (
            <label className="flex flex-col gap-1">
              <span className={cn("text-sm", error && "text-destructive")}>
                Image URL <b className="text-primary">*</b>
              </span>
              <Input
                placeholder="An URL for the bands image."
                value={value}
                className={cn(error && "text-destructive border-destructive")}
                onChange={onChange}
                disabled={disabled}
              />
              {error && (
                <span className="text-sm text-destructive">
                  {error.message}
                </span>
              )}
            </label>
          )}
        />
        <div className="flex gap-3">
          <FormField
            name="price"
            control={form.control}
            defaultValue={0}
            render={({
              field: { value, onChange, disabled },
              fieldState: { error },
            }) => (
              <label className="flex flex-col flex-1 gap-1">
                <span className={cn("text-sm", error && "text-destructive")}>
                  Price <b className="text-primary">*</b>
                </span>
                <Input
                  placeholder="How much does it cost?"
                  className={cn(error && "text-destructive border-destructive")}
                  value={value}
                  onChange={onChange}
                  disabled={disabled}
                />
                {error && (
                  <span className="text-sm text-destructive">
                    {error.message}
                  </span>
                )}
              </label>
            )}
          />

          <FormField
            name="capacity"
            control={form.control}
            defaultValue={0}
            render={({
              field: { value, onChange, disabled },
              fieldState: { error },
            }) => (
              <label className="flex flex-col flex-1 gap-1">
                <span className={cn("text-sm", error && "text-destructive")}>
                  Capacity <b className="text-primary">*</b>
                </span>
                <Input
                  disabled={disabled}
                  placeholder="How many people fit in this show?"
                  className={cn(error && "text-destructive border-destructive")}
                  value={value}
                  onChange={onChange}
                />
                {error && (
                  <span className="text-sm text-destructive">
                    {error.message}
                  </span>
                )}
              </label>
            )}
          />
        </div>
        <FormField
          name="date"
          defaultValue={new Date(Date.now())}
          control={form.control}
          render={({
            field: { value, onChange, disabled },
            fieldState: { error },
          }) => (
            <label className="flex flex-col gap-1">
              <span className={cn("text-sm", error && "text-destructive")}>
                Date <b className="text-primary">*</b>
              </span>
              <Input
                placeholder="When is this going to happen?"
                className={cn(error && "text-destructive border-destructive")}
                value={value.toISOString().split("T")[0]}
                onChange={onChange}
                disabled={disabled}
              />
              {error && (
                <span className="text-sm text-destructive">
                  {error.message}
                </span>
              )}
            </label>
          )}
        />
        <FormField
          name="description"
          defaultValue=""
          control={form.control}
          render={({
            field: { value, onChange, disabled },
            fieldState: { error },
          }) => (
            <label className="flex flex-col gap-1">
              <span className={cn("text-sm", error && "text-destructive")}>
                Description
              </span>
              <Input
                placeholder="Description"
                className={cn(error && "text-destructive border-destructive")}
                value={value ?? ""}
                onChange={onChange}
                disabled={disabled}
              />
              {error && (
                <span className="text-sm text-destructive">
                  {error.message}
                </span>
              )}
            </label>
          )}
        />
        <div className="flex justify-between">
          <Button variant="outline" type="reset" onClick={() => form.reset()}>
            Clean
          </Button>
          <Button type="submit">Submit</Button>
        </div>
      </form>
    </Form>
  );
}
