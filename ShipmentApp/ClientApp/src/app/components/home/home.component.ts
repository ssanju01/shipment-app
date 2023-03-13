import { Component, OnInit } from '@angular/core';
import { IQuoteDto } from '../../interfaces/iquote-dto';
import { QuotableService } from '../../services/quotable.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  randomQuote: IQuoteDto | undefined;

  constructor(private quotableService: QuotableService) {}

  ngOnInit(): void {
    this.getRandomQuote();
  }

  getRandomQuote(): void {
    this.quotableService.getRandomQuote().subscribe(res => {
      this.randomQuote = res;
    })
  }
}
