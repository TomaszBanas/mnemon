import { Component, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ParametersService } from 'src/app/services/parameters.service';

@Component({
  selector: 'app-geometry-generation-selection',
  templateUrl: './geometry-generation-selection.component.html',
  styleUrls: ['./geometry-generation-selection.component.scss']
})
export class GeometryGenerationSelectionComponent implements OnInit {

  public _config: any;
  public selectedConfig?: string | null;

  constructor(
    private parametersService: ParametersService, 
    private zone: NgZone, 
    private router: Router, 
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.parametersService.getConfig().then(c => {
      this._config = c;
    });
    this.route.queryParamMap.subscribe(paramMap => {
      this.zone.run(() => {
        this.selectedConfig = paramMap.get('id');
      });
    });
  }

  public onConfigChanged() {
    this.router.navigate(['edit'], {
      relativeTo:this.route,
      queryParams: {
        id: this.selectedConfig
      }
    });
  }

}
