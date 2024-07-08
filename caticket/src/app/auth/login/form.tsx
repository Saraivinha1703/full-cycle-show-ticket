"use client";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useFormState } from "react-dom";
import { Login } from "./action";
import { cn } from "@/lib/utils";

export function LoginForm() {
  const [state, formAction] = useFormState(Login, { errors: [] });
  const emailErrors = state.errors.filter((i) => i.path[0] === "email");
  const passwordErrors = state.errors.filter((i) => i.path[0] === "password");

  return (
    <main className="w-full h-[calc(100%-4rem)] flex justify-center items-center">
      <form
        className="transition-all duration-300 flex flex-col gap-6 w-full md:w-3/4 lg:w-1/2 border border-input rounded-lg p-4 hover:shadow-md hover:shadow-black/10"
        action={formAction}
      >
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
          <Button type="submit">Log In</Button>
          <Button variant="outline" type="reset">
            Clean
          </Button>
        </div>
      </form>
    </main>
  );
}
