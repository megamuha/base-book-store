import type { CreateUpdateOrderedBookDto, GetOrderedBookListDto, OrderedBookDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OrderedBookService {
  apiName = 'Default';

  create = (input: CreateUpdateOrderedBookDto) =>
    this.restService.request<any, OrderedBookDto>({
      method: 'POST',
      url: '/api/app/ordered-book',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/ordered-book/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, OrderedBookDto>({
      method: 'GET',
      url: `/api/app/ordered-book/${id}`,
    },
    { apiName: this.apiName });

  getClientList = (input: GetOrderedBookListDto) =>
    this.restService.request<any, PagedResultDto<OrderedBookDto>>({
      method: 'GET',
      url: '/api/app/ordered-book/client-list',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: GetOrderedBookListDto) =>
    this.restService.request<any, PagedResultDto<OrderedBookDto>>({
      method: 'GET',
      url: '/api/app/ordered-book',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateOrderedBookDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/ordered-book/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
