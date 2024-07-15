import "./globals.css";
import { Navbar } from "@/components/navbar";
import type { Metadata } from "next";
import { Monoton, Poppins, Syncopate } from "next/font/google";
import { ThemeProvider } from "next-themes";
import { Footer } from "@/components/footer";

const poppins = Poppins({ weight: "400", subsets: ["latin"] });
const monoton = Monoton({weight: "400", subsets: ["latin"], variable: "--font-monoton"})
const poiretOne = Syncopate({weight: "400", subsets: ["latin"], variable: "--font-poiret-one"})

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

      <body className={`${poppins.className} ${monoton.variable} ${poiretOne.variable} scrollbar`}>
        <ThemeProvider
          attribute="class"
          enableSystem
          enableColorScheme
          disableTransitionOnChange
          defaultTheme="system"
        >
          <Navbar />
          <div className="h-full flex flex-col justify-end">{children}</div>
          <Footer />
        </ThemeProvider>
      </body>
    </html>
  );
}
