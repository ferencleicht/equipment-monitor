"use client";

import { changeEquipmentState } from "@/app/(order)/update/actions";
import { FormControl } from "@chakra-ui/form-control";
import {
  Button,
  createListCollection,
  Portal,
  Select,
} from "@chakra-ui/react";
import { useState } from "react";

interface OrderFormProps {
  equipments: {
    label: string;
    value: string;
  }[];
}

const states = createListCollection({
  items: [
    {
      value: "2",
      label: "Green",
    },
    {
      value: "1",
      label: "Yellow",
    },
    {
      value: "0",
      label: "Red",
    },
  ],
});

export function OrderForm({equipments}: OrderFormProps) {
  const equipmentOptions = createListCollection({
    items: equipments.map((equipment) => ({
      value: equipment.value,
      label: equipment.label,
    })),
  });

  const [state, setState] = useState<string[]>([]);
  const [equipment, setEquipment] = useState<string[]>([]);

  const handleSubmit = async (formData: FormData) => {
    const selectedState = state[0];
    const selectedEquipment = equipment[0];

    if (selectedState && selectedEquipment) {
      formData.append("equipment", selectedEquipment);
      formData.append("state", selectedState);

      await changeEquipmentState(formData);
    }
  };

  return (
    <form action={handleSubmit}>
      <FormControl pb={8} isRequired>
        <Select.Root
          collection={equipmentOptions}
          value={equipment}
          onValueChange={(e) => setEquipment(e.value)}
        >
          <Select.HiddenSelect />
          <Select.Label>Equipment</Select.Label>
          <Select.Control>
            <Select.Trigger>
              <Select.ValueText placeholder="Select equipment" />
            </Select.Trigger>
            <Select.IndicatorGroup>
              <Select.Indicator />
            </Select.IndicatorGroup>
          </Select.Control>
          <Portal>
            <Select.Positioner>
              <Select.Content>
                {equipmentOptions.items.map((item) => (
                  <Select.Item item={item} key={item.value}>
                    {item.label}
                  </Select.Item>
                ))}
              </Select.Content>
            </Select.Positioner>
          </Portal>
        </Select.Root>
      </FormControl>
      <FormControl isRequired>
        <Select.Root
          collection={states}
          value={state}
          onValueChange={(e) => setState(e.value)}
        >
          <Select.HiddenSelect />
          <Select.Label>State</Select.Label>
          <Select.Control>
            <Select.Trigger>
              <Select.ValueText placeholder="Select equipment state" />
            </Select.Trigger>
            <Select.IndicatorGroup>
              <Select.Indicator />
            </Select.IndicatorGroup>
          </Select.Control>
          <Portal>
            <Select.Positioner>
              <Select.Content>
                {states.items.map((item) => (
                  <Select.Item item={item} key={item.value}>
                    {item.label}
                  </Select.Item>
                ))}
              </Select.Content>
            </Select.Positioner>
          </Portal>
        </Select.Root>
      </FormControl>
      <Button
        type="submit"
        mt={4}
        colorScheme="teal"
        disabled={!state.length || !equipment.length}
      >
        Submit
      </Button>
    </form>
  );
}
