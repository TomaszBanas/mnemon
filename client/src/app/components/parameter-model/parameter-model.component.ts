import { ChangeDetectorRef, Component, ElementRef, EventEmitter, Input, NgZone, OnInit, Output, ViewChild } from '@angular/core';
import { ParameterDefaultManager } from './parameter-default-manager';

interface ItemConfig
{
  id: string;
  name: string;
  properties: ConfigModel[];
}

interface ConfigModel
{
  name: string;
  property: string;
  type: string;
  metadata: string;
  data: any;
  collapsed: boolean;
  subData: ItemConfig
}


@Component({
  selector: 'app-parameter-model',
  templateUrl: './parameter-model.component.html',
  styleUrls: ['./parameter-model.component.scss']
})
export class ParameterModelComponent implements OnInit {

  @Input() set model(value : any)
  {
    this._model = value ?? {};
    this._model = this.handleDefaults(this._model, this._config);
    this.cd.detectChanges();
  }
  @Output() modelChange = new EventEmitter<number>();

  @Input() readonly!: boolean;

  @Input() set config(value : ConfigModel[])
  {
    this._config = (value ? value.map(x => {
      if(x.metadata)
        x.data = JSON.parse(x.metadata);
      return x
    }) : []) as ConfigModel[];
    this._model = this.handleDefaults(this._model, this._config);
    this.cd.detectChanges();
  }

  @ViewChild("Int32") Int32!: ElementRef;
  @ViewChild("MultiSelect") MultiSelect!: ElementRef;
  @ViewChild("Vector") Vector!: ElementRef;
  @ViewChild("Range") Range!: ElementRef;
  @ViewChild("Double") Double!: ElementRef;
  @ViewChild("Group") Group!: ElementRef;
  @ViewChild("ObjectList") ObjectList!: ElementRef;
  @ViewChild("Boolean") Boolean!: ElementRef;


  public _model: any;
  public _config!: ConfigModel[];

  constructor(private zone: NgZone, private cd: ChangeDetectorRef) { }

  ngOnInit(): void {
  }


  getTemplate(key: string): any {
    return (this as any)[key];
  }
  parse(json: string): any {
    return JSON.parse(json);
  }

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

  public emitModel() {
    this.modelChange.emit(this._model);
  }

  public addNew(config: any): void {
    this.zone.run(() => {
      var newModel = this.handleDefaults({}, config.subData.properties);
      this._model[config.property].push(newModel);
      this.emitModel();
    });
  }
  public duplicate(config: any, i: number): void {
    this.zone.run(() => {

      this._model[config.property].splice(i, 0, JSON.parse(JSON.stringify(this._model[config.property][i])));
      this.emitModel();
    });
  }
  public removeIndex(config: any, i: number): void {
    this._model[config.property].splice(i, 1);
    this.emitModel(); 
  }

  public handleDefaults(model: any, config: ConfigModel[]): any {
    const manager = new ParameterDefaultManager(config);
    return manager.handleDefault(model);
  }
}
