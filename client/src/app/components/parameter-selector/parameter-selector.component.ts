import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ParametersService } from 'src/app/services/parameters.service';

@Component({
  selector: 'app-parameter-selector',
  templateUrl: './parameter-selector.component.html',
  styleUrls: ['./parameter-selector.component.scss']
})
export class ParameterSelectorComponent implements OnInit {

  public _config: any;
  public selectedItemConfig: any = {};
  public _itemConfig: any;
  public _selectedConfig!: string;


  @Input() readonly!: boolean;
  @Input() set selectedConfig(v: string) {
    this._selectedConfig = v;
    this.loadConfig();
  }

  @Output() onConfirm = new EventEmitter<any>();

  constructor(private parametersService: ParametersService) { }

  ngOnInit(): void { }


  public loadConfig(): void {
    if(!this._selectedConfig) {
      this._itemConfig = null;
      return;
    }
    this.parametersService.getItemConfig(this._selectedConfig).then(c => {
      this._itemConfig = c;
      const storageData = localStorage.getItem(this._selectedConfig);
      this.selectedItemConfig = storageData ? JSON.parse(storageData) : null;
      setTimeout(() => {this.confirmProperties()}, 0); // to create model on start
    })
  }

  public selectedItemChanged() {
    const jsonData = JSON.stringify(this.selectedItemConfig);
    localStorage.setItem(this._selectedConfig, jsonData);
    this.confirmProperties();
  }

  public confirmProperties() {
    this.onConfirm.emit(
      {
        config: this._itemConfig,
        model: this.selectedItemConfig
      });
  }

}
