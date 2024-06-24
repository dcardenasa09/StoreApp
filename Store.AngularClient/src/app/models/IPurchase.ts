import { IClient } from "./IClient";

export interface IPurchase {
    id: number;
    folio: string;
    clientId: number;
    date: Date,
    total: number;
    status: number;
    observations: string;
    isActive: boolean;
    client?: IClient;
}
