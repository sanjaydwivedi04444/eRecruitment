import { Component, TemplateRef, OnInit, Input } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
  CompanyBriefDto,
  CompaniesClient,
  PaginatedListOfCompanyBriefDto
} from '../web-api-client';
import { Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { PagingConfig } from '../PagingConfig';

@Component({
  selector: 'app-companies-component',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss']
})
export class CompaniesComponent implements OnInit {
  debug = false;
  pageOfItems: Array<any>;
  companyDto: PaginatedListOfCompanyBriefDto;
  newJobModalRef: BsModalRef;
  newJobEditor: any = {};
  updateJobModalRef: BsModalRef;
  updateJobEditor: any = {};
  private searchText$ = new Subject<string>();
  pageSize = 5;
  currentPage = 1;
  pagingConfig: PagingConfig = {} as PagingConfig;
  totalItems:number= 0;
  constructor(
    private companiesClient: CompaniesClient,
    private modalService: BsModalService
  ) {
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

    this.companiesClient.getCompaniesWithPagination("", this.currentPage, this.pageSize).subscribe(
      result => {
        this.companyDto = result;
        this.pagingConfig = {
          itemsPerPage: this.pageSize,
          currentPage: this.currentPage,
          totalItems: this.companyDto.totalCount
        }
      },
      error => console.error(error)
    );
  }
  pageChanged(event: any) {
    debugger
    this.currentPage = event;
    this.companiesClient.getCompaniesWithPagination("", this.currentPage, this.pageSize).subscribe(
      result => {
        debugger
        this.companyDto = result;
        this.pagingConfig = {
          itemsPerPage: this.pageSize,
          currentPage: this.currentPage,
          totalItems: this.companyDto.totalCount
        }
      },
      error => console.error(error)
    );
  }
  searchJobs(sText: any) {
    debugger
    this.companiesClient.getCompaniesWithPagination(sText, 1, 10).subscribe(
      result => {
        this.companyDto = result;
        this.pagingConfig = {
          itemsPerPage: this.pageSize,
          currentPage: this.currentPage,
          totalItems: this.companyDto.totalCount
        }
      },
      error => console.error(error)
    );
  }
}
