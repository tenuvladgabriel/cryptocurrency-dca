import {inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class InvestmentDataService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7150/api/investments';

  getInvestmentsData(month: Date = new Date()): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
