import { ICinemaSeat } from "./ICinemaSeat";
import { IShow } from "./IShow";

export interface ICinemahall
{
  cinemaHallID:number;
  name:string,
  cinemaSeats:ICinemaSeat,
  show:IShow,
  cinemaID:number,


}
