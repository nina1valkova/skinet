import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';
import { ShopService } from './core/services/shop.service';
import { ShopComponent } from "./features/shop/shop.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, ShopComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent 
{
  title = 'Skinet';

  //private shopService = inject(ShopService);
  /*
  baseUrl = 'https://localhost:5025/api/'
  private http = inject(HttpClient);
  */

   //ince same tova ostava no sega go metia drugase v shopcomonent
      //title = 'Skinet';
      // products: Product[] = [];

      //ince same tova ostava no sega go metia drugase v shopcomonent
 // ngOnInit():void
 // {
    /* this.http.get<Pagination<Product>>(this.baseUrl + 'products').subscribe(*/
   // this.shopService.getProducts().subscribe({
      //next: data => console.log(data),
   //   next: response => this.products = response.data,
    //  error: error =>console.log(error)
      /*complete: () => console.log('complete')*/
   // })
    
  //}
}
