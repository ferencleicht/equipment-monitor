import { State } from "./equipment";

export type HistoryRecord = {
  id: string;
  equipmentId: string;
  equipmentName: string;
  previousState: State;
  newState: State;
  changedAt: string;
};
