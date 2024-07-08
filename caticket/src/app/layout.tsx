import "./globals.css";
import { Navbar } from "@/components/navbar";
import type { Metadata } from "next";
import { Poppins } from "next/font/google";
import { ThemeProvider } from "next-themes";

const poppins = Poppins({ weight: "400", subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Caticket",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <head>
        <link rel="icon" href="/logo.ico" sizes="any" />
      </head>

      <body className={poppins.className}>
        <ThemeProvider
          attribute="class"
          enableSystem
          enableColorScheme
          disableTransitionOnChange
        >
          <Navbar />
          <div className="h-full flex flex-col justify-end">{children}</div>
        </ThemeProvider>
      </body>
    </html>
  );
}
