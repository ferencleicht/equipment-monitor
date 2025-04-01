import { HistoryRecord } from "@/types";
import { Table } from "@chakra-ui/react";
import { StateTag } from "./state-tag";

interface HistoryProps {
  records: HistoryRecord[];
}

const columns = [
  { Header: "ID", accessor: "id" },
  { Header: "Equipment ID", accessor: "equipmentId" },
  { Header: "Equipment Name", accessor: "equipmentName" },
  { Header: "Previous State", accessor: "previousState" },
  { Header: "New State", accessor: "newState" },
  { Header: "Changed At", accessor: "changedAt" },
];

export function History({ records }: HistoryProps) {
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
        {records.map((record) => (
          <Table.Row key={record.id}>
            <Table.Cell>{record.id}</Table.Cell>
            <Table.Cell>{record.equipmentId}</Table.Cell>
            <Table.Cell>{record.equipmentName}</Table.Cell>
            <Table.Cell>
              <StateTag state={record.previousState} />
            </Table.Cell>
            <Table.Cell>
              <StateTag state={record.newState} />
            </Table.Cell>
            <Table.Cell>{new Date(record.changedAt).toUTCString()}</Table.Cell>
          </Table.Row>
        ))}
      </Table.Body>
    </Table.Root>
  );
}
