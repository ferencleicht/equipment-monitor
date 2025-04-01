import { Dashboard } from "@/components";
import { Equipment } from "@/types";
import { Button, Container, Flex, Link } from "@chakra-ui/react";
import NextLink from "next/link";

export default async function Page() {
  const response = await fetch(`${process.env.BACKEND_BASE_URL}/equipments`, {
    method: "GET",
  });

  const data = await response.json();

  const equipments: Equipment[] = data.map((equipment: any) => ({
    ...equipment,
    lastUpdated: new Date(equipment.lastUpdated),
  }));

  return (
    <Container
      centerContent
      maxW="container.xl"
      display="flex"
      alignItems="center"
      justifyContent="center"
    >
      <Dashboard equipments={equipments} />

      <Flex direction="row" justifyContent="space-between">
        <Link as={NextLink} href="/update">
          <Button m={4}>Change equipment state</Button>
        </Link>
        <Link as={NextLink} href="/history">
          <Button m={4}>History</Button>
        </Link>
      </Flex>
    </Container>
  );
}
