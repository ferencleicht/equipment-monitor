import { History } from "@/components";

export default async function Page() {
  const response = await fetch(`${process.env.BACKEND_BASE_URL}/history`, {
    method: "GET",
  });
  const data = await response.json();

  const history = data.map((history: any) => ({
    ...history,
    lastUpdated: new Date(history.lastUpdated),
  }));

  return <History records={history} />;
}
