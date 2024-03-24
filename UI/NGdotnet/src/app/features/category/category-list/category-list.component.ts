import { Component, OnInit } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, RouterOutlet, RouterLink, RouterLinkActive,
  CommonModule],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit {
  
  // categories?: Category[];
  categories$?: Observable<Category[]>
  constructor(private categoryService: CategoryService) {

  }
  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();


    // this.categoryService.getAllCategories()
    // .subscribe({
    //   next: (response) => {
    //     this.categories =response;
        
    //   }
    // })
  }



}
