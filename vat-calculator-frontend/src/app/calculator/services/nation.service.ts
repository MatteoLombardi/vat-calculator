import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Country } from "../models/country.model";
import { map } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NationService {
  constructor(private http: HttpClient){
  }

  baseUrl: string = "https://localhost:7230/api"

  retrieveCountries(){
    return this.http.get(`${this.baseUrl}/Countries`).pipe(
      map((res: Array<Country>) => {
        return res})
    )
  }
}
