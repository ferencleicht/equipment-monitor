"use client";

import { Table } from "@chakra-ui/react";
import { Equipment } from "@/types";
import { StateTag } from "./state-tag";

interface DashboardProps {
  equipments: Equipment[];
}

const columns = [
  { Header: "Name", accessor: "name" },
  { Header: "State", accessor: "state" },
  { Header: "Last Updated", accessor: "lastUpdated" },
];

export function Dashboard({ equipments }: DashboardProps) {
  return (
    <Table.Root size="sm" interactive variant="outline">
      <Table.Header>
        <Table.Row>
          {columns.map((column) => (
            <Table.ColumnHeader key={column.accessor}>
              {column.Header}
            </Table.ColumnHeader>
          ))}
        </Table.Row>
      </Table.Header>
      <Table.Body>
        {equipments.map((equipment) => (
          <Table.Row key={equipment.id}>
            <Table.Cell>{equipment.name}</Table.Cell>
            <Table.Cell>
              <StateTag state={equipment.state} />
            </Table.Cell>
            <Table.Cell>{equipment.lastUpdated.toUTCString()}</Table.Cell>
          </Table.Row>
        ))}
      </Table.Body>
    </Table.Root>
  );
}
