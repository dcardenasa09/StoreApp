import { IProduct } from "./IProduct";

export interface IPurchaseDetail {
    id: number;
    productStoreId: number;
    purchaseId: number;
    quantity: number;
    price: number;
    total: number;
    product?: IProduct;
}