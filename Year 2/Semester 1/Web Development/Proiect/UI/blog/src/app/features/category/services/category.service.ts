import { Injectable } from '@angular/core';
import { AddCategoryComponent } from '../add-category/add-category.component';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AddCategoryRequest } from '../models/add-category-request.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  addCategory(model: AddCategoryRequest): Observable<void>{
    return this.http.post<void>(`https://localhost:7029/api/categories`, model);
  }
}
