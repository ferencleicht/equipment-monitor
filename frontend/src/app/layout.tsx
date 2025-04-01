import type { Metadata } from "next";
import { Provider } from "@/components";


export const metadata: Metadata = {
  title: "LEGO Monitor",
  description: "Monitor equipments in the factory",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body>
        <Provider>{children}</Provider>
      </body>
    </html>
  );
}
