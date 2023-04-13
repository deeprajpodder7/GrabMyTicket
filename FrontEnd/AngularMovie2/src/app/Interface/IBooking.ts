import { IShow } from "./IShow";
import { IShowSeat } from "./IShowSeat";

export interface IBooking
{
  bookingID?:number;
  numberOfSeats:number,
  timeStamp:Date,
  status:number,
  userID:number,
  showID:number
}
