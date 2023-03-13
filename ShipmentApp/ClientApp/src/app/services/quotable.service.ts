import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagedQuotesDto } from '../interfaces/ipaged-quote-dto';
import { IQuoteDto } from '../interfaces/iquote-dto';

@Injectable({
  providedIn: 'root',
})
export class QuotableService {
  baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = 'https://localhost:7080/api';
  }

  getRandomQuote(): Observable<IQuoteDto> {
    return this.http.get<IQuoteDto>(`${this.baseUrl}/quotes/random`);
  }

  getAlbertQuotes(minLength: number, maxLength: number): Observable<IPagedQuotesDto> {
    return this.http.get<IPagedQuotesDto>(`${this.baseUrl}/quotes/search?limit=30&author=Albert Einstein&minLength=${minLength}&maxLength=${maxLength}`);
  }
}
