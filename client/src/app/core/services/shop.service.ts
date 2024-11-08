import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core'
import { Product } from '../../shared/models/product';
import { Pagination } from '../../shared/models/pagination';
import { ShopParams } from '../../shared/models/shopParams';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5025/api/'
  private http = inject(HttpClient);
  types: string[] = [];
  brands: string[] = [];

  getProducts(/*brands?: string[], types?: string[], sort?: string*/ shopParams: ShopParams) {
    let params = new HttpParams();

    if(/*brands && brands.length >0*/shopParams.brands.length>0)
    {
       params = params.append('brands', /*brands.join(',')*/ shopParams.brands.join(','));
    }

    if(/*types && types.length >0*/shopParams.types.length>0)
    {
      params = params.append('types', /*types.join(',')*/shopParams.types.join(','));
    }

    if(/*sort*/shopParams.sort)
    {
      params = params.append('sort', /*sort*/ shopParams.sort);
    }

    if(shopParams.search)
    {
      params = params.append('search', shopParams.search);
    }


    params = params.append('pageSize',shopParams.pageSize);
    //pageIndex - is in my APi is pageNumber
    params = params.append('pageIndex', shopParams.pageNumber);

                                             //query string for http request     
    return this.http.get<Pagination<Product>>(this.baseUrl + 'products' , {params})
  }

  getProduct(id: number)
  {
    return this.http.get<Product>(this.baseUrl + 'products/'+id);
  }

  getBrands() {
    if (this.brands.length > 0) {
      return
    }

    return this.http.get<string[]>(this.baseUrl + 'products/brands').subscribe(
      {
        next: response => this.brands = response
      })
  }

  getTypes() {
    if(this.types.length>0)
    {
      return
    }
    return this.http.get<string[]>(this.baseUrl + 'products/types').subscribe({
      next: response => this.types = response
    })
  }

}
