import { State } from "@/types";
import { Tag } from "@chakra-ui/react";

interface StateTagProps {
  state: State;
}

export function StateTag({ state }: StateTagProps) {
  const label =
    state == State.RED
      ? "Standing still"
      : state == State.YELLOW
      ? "Starting up or winding down"
      : "Producing LEGO bricks";

  const color =
    state == State.RED ? "red" : state == State.YELLOW ? "yellow" : "green";

  return (
    <Tag.Root size="sm" colorPalette={color} variant="solid">
      <Tag.Label>{label}</Tag.Label>
    </Tag.Root>
  );
}
