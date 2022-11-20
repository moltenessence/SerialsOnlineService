export interface IPurchase {
    id: number;
    amountOfMonths: number;
    date: string,
    totalPrice: number;
    subscription?: string;
}