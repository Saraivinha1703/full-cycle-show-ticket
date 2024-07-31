import { cn } from "@/lib/utils";
import { InputHTMLAttributes } from "react";

type RadioProps = InputHTMLAttributes<HTMLInputElement> & {
  name: string;
  label: {
    value: string;
    className?: string;
  };
};

export function Radio({ name, className, id, label, ...props }: RadioProps) {
  return (
    <label
      htmlFor={id}
      className={cn("flex gap-2 items-center cursor-pointer", label.className)}
    >
      <input
        type="radio"
        className={cn("peer hidden", className)}
        name={name}
        id={id}
        {...props}
      />
      <div className="w-3.5 h-3.5 rounded-full border border-foreground/50 bg-background/50 hover:border-foreground/70 peer-checked:bg-foreground" />
      <span>{label.value}</span>
    </label>
  );
}
