import {Component, inject, OnInit} from "@angular/core";
import {MatTableDataSource} from "@angular/material/table";
import {InvestmentInterface} from "../../dtos/investment";
import {InvestmentDataService} from "../../services/investment-data.service";

@Component({
  selector: 'app-investment-table',
  templateUrl: './investment-table.component.html',
  styleUrls: []
})
export class InvestmentTableComponent implements OnInit {
  private investmentDataService = inject(InvestmentDataService);
  displayedColumns: string[] = ['date', 'investedAmount', 'cryptoAmount', 'valueToday', 'roi'];
  dataSource = new MatTableDataSource<InvestmentInterface[]>();

  ngOnInit(): void {
    this.investmentDataService.getInvestmentsData().subscribe(data => this.dataSource.data = data);
  }
}
