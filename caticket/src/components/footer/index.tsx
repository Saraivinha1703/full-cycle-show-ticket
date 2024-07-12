import Link from "next/link";
import { PiEnvelope, PiGithubLogo, PiLinkedinLogo } from "react-icons/pi";

export function Footer() {
  return (
    <footer className="flex flex-col">
      <div className="flex flex-col gap-6 justify-between p-4 border-t border-input sm:flex-row sm:py-8 sm:px-12">
        <div className="flex flex-col gap-2">
          <h1 className="text-xl font-semibold sm:text-2xl">Contacts</h1>

          <div className="flex flex-col gap-1">
            <div className="flex gap-1 items-center sm:gap-2">
              <PiEnvelope size={20} />
              <Link
                className="text-xs sm:text-base hover:underline"
                target="_blank"
                href="mailto:carlos.saraiva.neto@gmail.com"
              >
                carlos.saraiva.neto@gmail.com
              </Link>
            </div>

            <div className="flex gap-1 items-center sm:gap-2">
              <PiLinkedinLogo size={20} />
              <Link
                className="text-xs sm:text-base hover:underline"
                target="_blank"
                href="https://www.linkedin.com/in/carlos-saraiva-neto/"
              >
                Carlos Saraiva
              </Link>
            </div>
          </div>
        </div>

        <div className="flex items-center gap-2 font-extralight text-xs sm:text-sm">
          <PiGithubLogo size={17} />
          <Link
            href="https://github.com/Saraivinha1703/full-cycle-show-ticket"
            target="_blank"
            className="hover:underline"
          >
            Source code
          </Link>
        </div>
      </div>

      <div className="flex w-full justify-center font-light text-xs sm:text-sm">
        <span>
          © 2024-{new Date(Date.now()).getUTCFullYear()} Carlos Alberto Saraiva
          Neto
        </span>
      </div>
    </footer>
  );
}
