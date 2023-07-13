import { Reservaandres } from './../models/reservaandres';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservaandresService {

  constructor(private Http:HttpClient) { }
  url:string ="http://localhost:58912/api/Reservaandres";


  getReservaandres(){
    return this.Http.get(this.url);

  }
addReservaandres(reservaandres:Reservaandres):Observable<Reservaandres>{
return this.Http.post<Reservaandres>(this.url,reservaandres)
}
updateReservaandres(id:number, reservaandres:Reservaandres):Observable<Reservaandres>{
  return this.Http.put<Reservaandres>(this.url +   `/${id}`, reservaandres);

}
deleteReservaandres(id:number){
  return this.Http.delete(this.url + `/${id}`);
}

}
