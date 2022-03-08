import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ParametersService {

  public get configUrl() {
    return environment.generatorApi + "/Parameters/Config";
  }

  public get itemConfigUrl() {
    return environment.generatorApi + "/Parameters/ItemConfig";
  }

  private _config: any;

  constructor(private http: HttpClient) { }
  
  public getConfig() : Promise<any>{
    return new Promise((resolve) => {
      if(this._config) {
        resolve(this._config);
        return;
      }
      this.callGetConfig().subscribe(config => {
        this._config = config;
        resolve(this._config);
      });
    });
  }
  public getItemConfig(id: string) : Promise<any>{
    return new Promise((resolve) => {
      this.http.get(this.itemConfigUrl + "?id=" + id).subscribe(resolve);
    });
  }
  
  public generate(config: any, model: any) : Promise<any>{
    return new Promise((resolve) => {
      if(!config || !config.data || !config.data.generateEndpoint) {
        resolve(null);
        return
      }
      if(!model) {
        model = {};
      }

      this.http.post(environment.generatorApi + "/" + config.data.generateEndpoint, model).subscribe(resolve);
    });
  }

  private callGetConfig(): Observable<Object> {
    return this.http.get(this.configUrl);
  }
}
