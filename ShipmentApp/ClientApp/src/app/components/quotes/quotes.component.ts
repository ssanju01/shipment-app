import { Component, OnInit } from '@angular/core';
import { IQuoteDto } from '../../interfaces/iquote-dto';
import { QuotableService } from '../../services/quotable.service';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.css'],
})
export class QuotesComponent implements OnInit {
  quotes: IQuoteDto[] = [];
  length: string = 'l';

  constructor(private quotableService: QuotableService) {}

  ngOnInit(): void {
    this.getAlbertQuotes();
  }

  getAlbertQuotes(): void {
    let minLength = 0;
    let maxLength = 10;

    switch (this.length) {
      case 's':
        minLength = 0;
        maxLength = 10;
        break;
      case 'm':
        minLength = 11;
        maxLength = 20;
        break;
      case 'l':
        minLength = 21;
        maxLength = 50000;
        break;
    }
    this.quotableService.getAlbertQuotes(minLength, maxLength).subscribe((res) => {
      this.quotes = res.results;
    });
  }

  lengthChanged(): void {
    this.getAlbertQuotes();
  }
}
