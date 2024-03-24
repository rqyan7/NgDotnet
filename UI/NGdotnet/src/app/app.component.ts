import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./core/components/navbar/navbar.component";
import { CategoryService } from './features/category/services/category.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, NavbarComponent, RouterOutlet, RouterLink, 
      RouterLinkActive, HttpClientModule,CommonModule
    ],
    providers: [
      CategoryService
    ]
})
export class AppComponent {
  title = 'NGdotnet';
}
