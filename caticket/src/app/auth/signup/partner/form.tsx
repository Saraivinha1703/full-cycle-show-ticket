"use client";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useFormState } from "react-dom";
import { SignUpPartner } from "./action";
import { cn } from "@/lib/utils";
import { useEffect, useState } from "react";
import { PiSpinnerGap } from "react-icons/pi";

export function SignUpPartnerForm() {
  const [isMounted, setIsMounted] = useState(false);
  const [state, formAction] = useFormState(SignUpPartner, { errors: [] });

  const nameErrors = state.errors.filter((i) => i.path[0] === "name");
  const emailErrors = state.errors.filter((i) => i.path[0] === "email");
  const passwordErrors = state.errors.filter((i) => i.path[0] === "password");
  const confirmPasswordErrors = state.errors.filter((i) => i.path[0] === "confirmPassword");

  useEffect(() => {
    setIsMounted(true);
  }, []);

  if (!isMounted) return (
    <main className="w-full h-screen flex justify-center items-center">
      <PiSpinnerGap className="text-accent w-12 h-12 animate-spin" />
    </main>
  );

  return (
    <main className="w-full h-screen flex justify-center items-center">
      <div className="p-[0.08rem] rounded-lg w-full md:w-3/4 lg:w-1/2 bg-gradient-to-tr from-primary to-secondary">
      <form
        className="transition-all duration-300 flex flex-col gap-6 w-full bg-background border border-input rounded-lg p-4 hover:shadow-md hover:shadow-black/10"
        action={formAction}
        >
        <h1 className="text-2xl font-bold bg-gradient-to-tr from-primary to-secondary bg-clip-text text-transparent">Sign Up as Partner</h1>
        <div className="flex flex-col gap-2">
          <Input
            type="text"
            placeholder="Name"
            className={cn(
              nameErrors.length > 0 &&
              "border-destructive text-destructive placeholder-destructive/40"
            )}
            name="name"
            />

          {nameErrors.map((i, idx) => (
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
        
        <div className="flex flex-col gap-2">
          <Input
            type="password"
            placeholder="Confirm Password"
            className={cn(
              confirmPasswordErrors.length > 0 &&
              "border-destructive text-destructive placeholder-destructive/40"
            )}
            name="confirmPassword"
            />
          {confirmPasswordErrors.map((i, idx) => (
            <span
            key={idx}
            className="pl-4 text-destructive text-sm font-semibold"
            >
              {i.message}
            </span>
          ))}
        </div>

        <div className="flex justify-evenly w-full">
          <Button type="submit">Submit</Button>
          <Button variant="outline" type="reset">
            Clean
          </Button>
        </div>
      </form>
          </div>
    </main>
  );
}
