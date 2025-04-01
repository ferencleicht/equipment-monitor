import { OrderForm } from "@/components";
import { Container, Text } from "@chakra-ui/react";

export default async function Page() {
  const response = await fetch(`${process.env.BACKEND_BASE_URL}/equipments`, {
    method: "GET",
  });

  const data = await response.json();

  const equipments = data.map((equipment: any) => ({
    value: equipment.id,
    label: equipment.name,
  }));

  return (
    <Container
      centerContent
      maxW="container.xl"
      display="flex"
      alignItems="center"
      justifyContent="center"
    >
      <Text fontSize="2xl" p={4}>
        Change equipment state
      </Text>
      <OrderForm equipments={equipments} />
    </Container>
  );
}
