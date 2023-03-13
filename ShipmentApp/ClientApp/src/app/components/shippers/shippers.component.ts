import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IShipperDto } from '../../interfaces/ishipper-dto';
import { ShipperService } from '../../services/shipper.service';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css'],
})
export class ShippersComponent implements OnInit {
  shippers: IShipperDto[] = [];

  constructor(private shipperService: ShipperService, private router: Router) {}

  ngOnInit(): void {
    this.getAllShippers();
  }

  getAllShippers(): void {
    this.shipperService.getAllShippers().subscribe((res) => {
      this.shippers = res;
    });
  }

  gotoDetailPage(shipperId: number) {
    this.router.navigate([`/shipper/detail`, shipperId]);
  }
}
