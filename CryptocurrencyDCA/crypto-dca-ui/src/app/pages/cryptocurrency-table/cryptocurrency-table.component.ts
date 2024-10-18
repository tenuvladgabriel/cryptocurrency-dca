import {Component, inject, OnInit} from "@angular/core";
import {MatTableDataSource} from "@angular/material/table";
import {CryptoDataService} from "../../services/crypto-data.service";
import {CryptoCurrencyInterface} from "../../dtos/cryptocurrency";

@Component({
  selector: 'app-cryptocurrency-table',
  templateUrl: './cryptocurrency-table.component.html',
  styleUrls: []
})
export class CryptocurrencyTableComponent implements OnInit {
  private cryptoDataService = inject(CryptoDataService);
  displayedColumns: string[] = ['name', 'symbol', 'currentPrice'];
  dataSource = new MatTableDataSource<CryptoCurrencyInterface[]>();

  ngOnInit(): void {
    this.cryptoDataService.getCryptoData().subscribe(data => this.dataSource.data = data)
  }
}
