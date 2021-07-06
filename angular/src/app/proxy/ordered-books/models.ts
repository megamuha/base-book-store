import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateOrderedBookDto {
  bookId?: string;
}

export interface OrderedBookDto extends AuditedEntityDto<string> {
  clientId?: string;
  bookId?: string;
  bookName?: string;
  clientName?: string;
  status?: string;
  details?: string;
}
