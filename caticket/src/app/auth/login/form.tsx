"use client";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useFormState, useFormStatus } from "react-dom";
import { Login } from "./action";
import { cn } from "@/lib/utils";
import { useEffect, useState } from "react";
import { PiSpinnerGap } from "react-icons/pi";

export function LoginForm() {
  const [isMounted, setIsMounted] = useState(false);
  const [state, formAction] = useFormState(Login, {
    errors: { zod: [], server: undefined },
  });

  const emailErrors = state?.errors.zod
    ? state.errors.zod.filter((i) => i.path[0] === "email")
    : [];

  const passwordErrors = state?.errors.zod
    ? state.errors.zod.filter((i) => i.path[0] === "password")
    : [];

  useEffect(() => {
    setIsMounted(true);
  }, []);

  if (!isMounted)
    return (
      <main className="w-full h-screen flex justify-center items-center">
        <PiSpinnerGap className="text-accent w-12 h-12 animate-spin" />
      </main>
    );

  return (
    <main className="w-full h-screen flex justify-center items-center p-4 sm:p-0">
      <form
        className="transition-all duration-300 flex flex-col gap-6 w-full md:w-3/4 lg:w-1/2 border border-input rounded-lg p-4 hover:shadow-md hover:shadow-black/10"
        action={formAction}
      >
        {state?.errors.server !== undefined && (
          <ol className="flex flex-col gap-1 list-decimal px-6 border border-destructive py-2 rounded-md">
            {state?.errors.server.map((err, idx) => (
              <li
                key={idx}
                className="text-destructive font-semibold tracking-wider text-sm"
              >
                {err}
              </li>
            ))}
          </ol>
        )}

        <h1 className="text-2xl font-semibold">Log In</h1>
        <div className="flex flex-col gap-2">
          <Input
            type="text"
            placeholder="Email"
            className={cn(
              emailErrors.length > 0 &&
                "border-destructive text-destructive placeholder-destructive/40"
            )}
            name="email"
          />

          {emailErrors.map((i, idx) => (
            <span
              key={idx}
              className="pl-4 text-destructive text-sm font-semibold"
            >
              {i.message}
            </span>
          ))}
        </div>

        <div className="flex flex-col gap-2">
          <Input
            type="password"
            placeholder="Password"
            className={cn(
              passwordErrors.length > 0 &&
                "border-destructive text-destructive placeholder-destructive/40"
            )}
            name="password"
          />
          {passwordErrors.map((i, idx) => (
            <span
              key={idx}
              className="pl-4 text-destructive text-sm font-semibold"
            >
              {i.message}
            </span>
          ))}
        </div>

        <div className="flex justify-evenly w-full">
          <SubmitForm />
          <Button variant="outline" type="reset">
            Clean
          </Button>
        </div>
      </form>
    </main>
  );
}

function SubmitForm() {
  const { pending } = useFormStatus();

  return (
    <Button type="submit" disabled={pending}>
      Submit
    </Button>
  );
}
