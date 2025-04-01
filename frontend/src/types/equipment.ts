export type Equipment = {
    id: string;
    name: string;
    state: State;
    lastUpdated: Date;
};

export enum State {
    RED = 0,
    YELLOW = 1,
    GREEN = 2,
};

