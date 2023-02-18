import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  driverApiUrl="https://localhost:7079/api/Driver/";
  constructor(private http: HttpClient) {
  }
  getAllDrivers() {

    return this.http.get(this.driverApiUrl,  {  })
        .pipe(map(res => res));
  }

  addDriver(data:any) {
    const body = JSON.stringify(data);
    return this.http.post(this.driverApiUrl , body,  { headers: this.getHeaders() })
      .pipe(map(res => res));

  }

  editDriver(data:any) {
    const body = JSON.stringify(data);
    return this.http.put(this.driverApiUrl, body,  { headers: this.getHeaders() })
      .pipe(map(res => res));

  }
  deleteDriver(id:any) {
    return this.http.delete(this.driverApiUrl+id, { headers: this.getHeaders() })
      .pipe(map(res => res));
  }

  private getHeaders() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    //we can add here token
    return headers;
  }
}
