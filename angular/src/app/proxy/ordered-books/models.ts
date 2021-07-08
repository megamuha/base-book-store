import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateOrderedBookDto {
  bookId?: string;
  clientId?: string;
}

export interface GetOrderedBookListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface OrderedBookDto extends AuditedEntityDto<string> {
  clientId?: string;
  bookId?: string;
  bookName?: string;
  clientName?: string;
}
