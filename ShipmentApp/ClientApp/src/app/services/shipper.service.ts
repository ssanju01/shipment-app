import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IShipperDto } from '../interfaces/ishipper-dto';
import { IShipperShipmentDetailDto } from '../interfaces/ishipper-shipment-detail-dto';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  baseUrl: string;

  headers = new HttpHeaders({
    "Content-Type": "application/json",
    "Accept": "application/json"
  });

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getAllShippers(): Observable<IShipperDto[]> {
    return this.http.get<IShipperDto[]>(this.baseUrl + "shipper");
  }

  getShipperShipment(shipperId: number): Observable<IShipperShipmentDetailDto[]> {
    return this.http.get<IShipperShipmentDetailDto[]>(this.baseUrl + "Shipment?id=" + shipperId);
  }
}
