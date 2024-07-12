import { Component, Input } from '@angular/core';
import {
  JobsClient, 
  PaginatedListOfJobBriefDto
} from '../web-api-client';
import { Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { PagingConfig } from '../PagingConfig';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  debug = false;
  pageOfItems: Array<any>;
  jobDto: PaginatedListOfJobBriefDto;
  private searchText$ = new Subject<string>();
  pageSize = 5;
  currentPage = 1;
  pagingConfig: PagingConfig = {} as PagingConfig;
  totalItems: number = 0;
  constructor(private jobsClient: JobsClient)
  {
    this.pagingConfig = {
      itemsPerPage: this.pageSize,
      currentPage: this.currentPage,
      totalItems: this.totalItems
    }
  }
  @Input() job: any;
  getValue(event: Event): string {
    debugger
    return (event.target as HTMLInputElement).value;
  }
  search(searchText: string) {
    debugger
    this.searchText$.next(searchText);
  }
  ngOnInit(): void {
    var response = this.searchText$.pipe(debounceTime(500)).subscribe((value: any) => {
      this.searchJobs(value);
    });

    this.jobsClient.getJobsWithPagination("", this.currentPage, this.pageSize).subscribe(
      result => {
        this.jobDto = result;
        this.pagingConfig = {
          itemsPerPage: this.pageSize,
          currentPage: this.currentPage,
          totalItems: this.jobDto.totalCount
        }
      },
      error => console.error(error)
    );
  }
  pageChanged(event: any) {
    debugger
    this.currentPage = event;
    this.jobsClient.getJobsWithPagination("", this.currentPage, this.pageSize).subscribe(
      result => {
        debugger
        this.jobDto = result;
        this.pagingConfig = {
          itemsPerPage: this.pageSize,
          currentPage: this.currentPage,
          totalItems: this.jobDto.totalCount
        }
      },
      error => console.error(error)
    );
  }
  searchJobs(sText: any) {
    debugger
    this.jobsClient.getJobsWithPagination(sText, 1, 10).subscribe(
      result => {
        this.jobDto = result;
        this.pagingConfig = {
          itemsPerPage: this.pageSize,
          currentPage: this.currentPage,
          totalItems: this.jobDto.totalCount
        }
      },
      error => console.error(error)
    );
  }
}
