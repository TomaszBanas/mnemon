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
  public _model: string | undefined;


  @Input() readonly!: boolean;
  @Input() set selectedConfig(v: string) {
    this._selectedConfig = v;
    this.loadConfig();
  }
  @Input() set model(v: string) {
    this.selectedItemConfig = v;
    if(!this.selectedItemConfig)
    {
      const storageData = localStorage.getItem(this._selectedConfig);
      this.selectedItemConfig = storageData ? JSON.parse(storageData) : null;
    }
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
      this.confirmProperties();
    })
  }

  public selectedItemChanged() {
    localStorage.setItem(this._selectedConfig, JSON.stringify(this.selectedItemConfig));
    this.confirmProperties();
  }

  public confirmProperties() {
    if(!this.selectedItemConfig)
      return;
    this.onConfirm.emit(
      {
        config: this._itemConfig,
        model: this.selectedItemConfig
      });
  }

}
