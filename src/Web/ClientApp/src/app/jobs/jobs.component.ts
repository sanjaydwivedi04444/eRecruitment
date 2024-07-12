import { Component, TemplateRef, OnInit, Input } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
    CreateJobCommand,
  JobBriefDto,
  JobsClient, LookupDto,
  PaginatedListOfJobBriefDto,
  UpdateJobCommand, UpdateJobDetailCommand
} from '../web-api-client';
import { Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { PagingConfig } from '../PagingConfig';

@Component({
  selector: 'app-job-component',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobComponent implements OnInit {
  debug = false;
  pageOfItems: Array<any>;
  jobDto: PaginatedListOfJobBriefDto;
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
    private jobsClient: JobsClient,
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
  showNewJobModal(template: TemplateRef<any>): void {
    this.newJobModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById('title').focus(), 250);
  }
  showUpdateJobModal(template: TemplateRef<any>, item: any): void {
    console.log(item.id);
    this.updateJobEditor.id=item.id,
      this.updateJobEditor.title=item.title,
      this.updateJobEditor.jobDescriptions = item.jobDescriptions,
      this.updateJobEditor.education = item.education,
      this.updateJobEditor.employer = item.employer,
      this.updateJobEditor.employmentType = item.employmentType,
      this.updateJobEditor.experience = item.experience,
      this.updateJobEditor.industryType = item.industryType,
      this.updateJobEditor.keySkills = item.keySkills,
      this.updateJobEditor.location = item.location,
      this.updateJobEditor.openings = item.openings,
      this.updateJobEditor.role = item.role,
      this.updateJobEditor.salary = item.salary,
      this.updateJobEditor.workMode = item.workMode
    this.updateJobModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById('title').focus(), 250);
  }
  updateJobCancelled(): void {
    this.updateJobModalRef.hide();
    this.updateJobEditor = {};
  }
  newJobCancelled(): void {
    this.newJobModalRef.hide();
    this.newJobEditor = {};
  }
  addJob(): void {
    const addJobDto = {
      id: 0,
      title: this.newJobEditor.title,
      jobDescriptions: this.newJobEditor.jobDescriptions,
      education: this.newJobEditor.education,
      employer: this.newJobEditor.employer,
      employmentType: this.newJobEditor.employmentType,
      experience: this.newJobEditor.experience,
      industryType: this.newJobEditor.industryType,
      keySkills: this.newJobEditor.keySkills,
      location: this.newJobEditor.location,
      openings: this.newJobEditor.openings,
      role: this.newJobEditor.role,
      salary: this.newJobEditor.salary,
      workMode: this.newJobEditor.workMode
    } as JobBriefDto;

    this.jobsClient.createJob(addJobDto as CreateJobCommand).subscribe(
      result => {
        alert(result.toString());
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        if (errors && errors.Title) {
          this.newJobEditor.error = errors.Title[0];
        }
        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }
  updateJob(): void {
    const updateJobDto = {
      id: this.updateJobEditor.id,
      title: this.updateJobEditor.title,
      jobDescriptions: this.updateJobEditor.jobDescriptions,
      education: this.updateJobEditor.education,
      employer: this.updateJobEditor.employer,
      employmentType: this.updateJobEditor.employmentType,
      experience: this.updateJobEditor.experience,
      industryType: this.updateJobEditor.industryType,
      keySkills: this.updateJobEditor.keySkills,
      location: this.updateJobEditor.location,
      openings: this.updateJobEditor.openings,
      role: this.updateJobEditor.role,
      salary: this.updateJobEditor.salary,
      workMode: this.updateJobEditor.workMode
    } as JobBriefDto;

    this.jobsClient.updateJobDetail(updateJobDto.id, updateJobDto as UpdateJobDetailCommand).subscribe(
      result => {
        alert(result);
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        if (errors && errors.Title) {
          this.updateJobEditor.error = errors.Title[0];
        }
        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }
}
