import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';
import { environment } from '../../../../environments/environment';
import { UpdateCategoryRequest } from '../models/update-catefory-request.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  addCategory(model: AddCategoryRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Categories`, model) ;
  }//same function as below but can use env url

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('https://localhost:7042/api/Categories');
  }

  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`https://localhost:7042/api/Categories/${id}`);
  }

  updateCategory(id: string, updateCategoryRequest: UpdateCategoryRequest): Observable<Category> {
    return this.http.put<Category>(`https://localhost:7042/api/Categories/${id}`, updateCategoryRequest);
  }
}
