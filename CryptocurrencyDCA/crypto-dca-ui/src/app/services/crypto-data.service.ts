import {inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CryptoDataService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7150/api/cryptocurrencies';

  getCryptoData(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
