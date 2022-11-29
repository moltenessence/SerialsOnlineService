import { ISerial } from "./ISerial";
import { ISerialRatings } from "./ISerialRatings";

export interface ISerialWithRatings {
    serial : ISerial;
    ratings: ISerialRatings;
}