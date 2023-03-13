import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IShipperShipmentDetailDto } from '../../interfaces/ishipper-shipment-detail-dto';
import { ShipperService } from '../../services/shipper.service';

@Component({
  selector: 'app-shipment-detail',
  templateUrl: './shipment-detail.component.html',
  styleUrls: ['./shipment-detail.component.css']
})
export class ShipmentDetailComponent implements OnInit {
  shipperId: number | undefined;
  shipments: IShipperShipmentDetailDto[] = [];
  shipperName: string = "None";

  constructor(private route: ActivatedRoute, private shipperService: ShipperService) { }

  ngOnInit(): void {
    this.route.params.subscribe(param => {
      this.shipperId = param["id"];
      this.getShipmentDetail();
    });
  }

  getShipmentDetail(): void {
    this.shipperService.getShipperShipment(this.shipperId!).subscribe(res => {
      this.shipments = res;
      if(res && res.length) {
        this.shipperName = res[0].shipper_name;
      } else {
        this.shipperName = "None";
      }
      console.log(res);
    });
  }

}
