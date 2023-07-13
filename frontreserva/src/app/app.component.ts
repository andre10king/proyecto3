import { ReservaandresService } from './services/reservaandres.service';
import { Reservaandres } from './models/reservaandres';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
reservaandres:Reservaandres = new Reservaandres();
datatable:any = [];
constructor(private reservaandresService:ReservaandresService){

}

ngOnInit(): void {
  this.onDataTable();
}

onDataTable(){
  this.reservaandresService.getReservaandres().subscribe(res=>{
this.datatable = res;
console.log(res);
  });
}


onAddReservaandres(reservaandres:Reservaandres):void{
  this.reservaandresService.addReservaandres(reservaandres).subscribe(res =>{

  if(res){
    alert(`la reserva de ${reservaandres.nombre} se ha grabado con exito`);
    this.clear();
    this.onDataTable();
  } else {
    alert('Error! ')
  }

  })
}


onUpdateReservaandres(reservaandres:Reservaandres):void{
  this.reservaandresService.updateReservaandres(reservaandres.id,reservaandres).subscribe(res =>{

if(res){
  alert(`La reserva ${reservaandres.id} de ha actualizado`);
  this.clear();
  this.onDataTable();

}else{
  alert(`Error`)
}

})
}

onDeleteReservaandres(id:number):void{
  this.reservaandresService.deleteReservaandres(id).subscribe(res=>{

if(res){
  alert(`la reserva${id} ha sido eliminada satisfactoriamente`);

}else{
  alert(`Error`)
}




  

})

}








onSetData(select:any){
  this.reservaandres.id = select.idReserva;
  this.reservaandres.nombre = select.nombre;
  this.reservaandres.origen = select.origen;
  this.reservaandres.destino = select.destino;
  this.reservaandres.categoria =select.categoria;
  this.reservaandres.cantpasj =select.cantpasj;
  this.reservaandres.cedula =select.cedula; 
}



clear(){
  this.reservaandres.id =0;
  this.reservaandres.nombre="";
  this.reservaandres.origen = "";
  this.reservaandres.destino= "";
  this.reservaandres.categoria = "";
  this.reservaandres.cantpasj=0;
  this.reservaandres.cedula="";
}



}