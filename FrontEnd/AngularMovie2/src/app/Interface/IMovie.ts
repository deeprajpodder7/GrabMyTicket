import { IGenre } from "./IGenre";

export interface IMovie
{
    movieID:number,
    title:string,
    imgLink:string,
    description:string,
    duration:number,
    language:number,
    releaseDate:Date,
    censorship:string,
    country:string,
    genres:IGenre,
    trailerLink:string


}
