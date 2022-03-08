import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TreeGeneratorService {

  constructor(private http: HttpClient) { }

  public generateTree(model: any): Observable<Object>
  {
    return this.http.post("https://localhost:7299/TreeGenerator/Generate", model);
  }
}
