export interface IProduct {
    id: number;
    key: string;
    description: string;
    urlImage: string;
    price: number;
    stock: number;
    productStores?: IProductStore[]
}

export interface IProductStore {
    id: number;
    branchStoreId: number;
    productId: number;
    date: Date;
    isActive: boolean;
}