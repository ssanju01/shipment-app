import { IQuoteDto } from "./iquote-dto";

export interface IPagedQuotesDto {
  count: number;
  totalCount: number;
  page: number;
  totalPages: number;
  lastItemIndex: number;
  results: IQuoteDto[];
}
