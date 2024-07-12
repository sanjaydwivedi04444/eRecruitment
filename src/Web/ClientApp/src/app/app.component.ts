import { Component } from '@angular/core';
import { PagingConfig } from './PagingConfig';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements PagingConfig{
  title = 'app';
  currentPage: number = 1;
  itemsPerPage: number = 5;
  totalItems: number = 0;
}
