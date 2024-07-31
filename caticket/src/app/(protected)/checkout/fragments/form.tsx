"use client";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Skeleton } from "@/components/ui/skeleton";
import { useEffect, useState } from "react";
import { IoCardOutline } from "react-icons/io5";

export function CheckoutForm() {
  const [mounted, isMounted] = useState(false);

  useEffect(() => {
    isMounted(true);
  }, []);

  if (!mounted)
    return (
      <Skeleton className="flex flex-col flex-1 gap-8 p-4 rounded-lg sm:p-8">
        <div className="flex gap-2 items-center">
          <Skeleton className="h-8 w-72 font-semibold tracking-wider" />
          <Skeleton className="w-6 h-6" />
        </div>

        <div className="flex flex-col gap-8">
          <div className="flex flex-col gap-4">
            <div className="flex flex-col gap-1">
              <Skeleton className="h-5 w-14" />
              <Skeleton className="h-10 w-full" />
            </div>

            <div className="flex flex-col gap-1">
              <Skeleton className="h-5 w-20" />
              <Skeleton className="h-10 w-full" />
            </div>

            <div className="flex flex-col gap-1">
              <Skeleton className="h-5 w-24" />
              <Skeleton className="h-10 w-full" />
            </div>

            <div className="flex gap-8">
              <div className="flex flex-col flex-1 gap-1">
                <Skeleton className="h-5 w-24" />
                <Skeleton className="h-10 w-full" />
              </div>

              <div className="flex flex-col flex-1 gap-1">
                <Skeleton className="h-5 w-14" />
                <Skeleton className="h-10 w-full" />
              </div>
            </div>
          </div>

          <Skeleton className="w-full h-10" />
        </div>
      </Skeleton>
    );

  return (
    <div className="flex flex-col flex-1 gap-8 p-4 rounded-lg border border-primary sm:p-8">
      <div className="flex gap-2 items-center">
        <h1 className="text-2xl font-semibold tracking-wider">
          Payment information
        </h1>
        <IoCardOutline className="w-6 h-6" />
      </div>

      <form className="flex flex-col gap-8">
        <div className="flex flex-col gap-4">
          <div className="flex flex-col gap-1">
            <label htmlFor="email">Email</label>
            <Input name="email" />
          </div>

          <div className="flex flex-col gap-1">
            <label htmlFor="card-owner">Card owner</label>
            <Input name="card-owner" />
          </div>

          <div className="flex flex-col gap-1">
            <label htmlFor="card-number">Card number</label>
            <Input name="card-number" />
          </div>

          <div className="flex gap-8">
            <div className="flex flex-col flex-1 gap-1">
              <label htmlFor="expiration-date">Expiration date</label>
              <Input name="expiration-date" />
            </div>

            <div className="flex flex-col flex-1 gap-1">
              <label htmlFor="cvv">CVV</label>
              <Input name="cvv" />
            </div>
          </div>
        </div>

        <Button className="uppercase font-semibold tracking-wider">Pay</Button>
      </form>
    </div>
  );
}
