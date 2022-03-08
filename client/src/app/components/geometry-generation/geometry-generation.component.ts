import { Component, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomOrthographicCamera } from 'src/app/cameras/orthographic-camera';
import { Geometry } from 'src/app/implementations/shared/models/geometry';
import { Line } from 'src/app/implementations/shared/models/line';
import { TestEngine } from 'src/app/implementations/test1/engine/test-engine';
import { MainModelMock } from 'src/app/implementations/test1/models/main-model.mock';
import { ICamera } from 'src/app/interfaces/i-camera';
import { IScene } from 'src/app/interfaces/i-scene';
import { ParametersService } from 'src/app/services/parameters.service';
import { RenderersProviderService } from 'src/app/services/renderers-provider.service';

@Component({
  selector: 'app-geometry-generation',
  templateUrl: './geometry-generation.component.html',
  styleUrls: ['./geometry-generation.component.scss']
})
export class GeometryGenerationComponent {

  public engine?: TestEngine;
  public mainScene?: IScene;
  public camera?: ICamera;
  public selectedConfig?: string | null;
  public readonly!: boolean;
  
  public interval!: any;

  constructor(
    private renderersProvider: RenderersProviderService,
    private parametersService: ParametersService,
    private zone: NgZone,
    private route: ActivatedRoute
    ) {
    const renderer = this.renderersProvider.get();
    this.engine = new TestEngine(MainModelMock.instance.mock ,renderer);
    this.camera = new CustomOrthographicCamera();
    this.engine.setCamera(this.camera);

    this.engine.render();
    (window as any)["testProxy"] = this.engine;
  }

  ngOnInit() {
    this.route.queryParamMap.subscribe(paramMap => {
      this.zone.run(() => {
        this.selectedConfig = paramMap.get('id');
      });
    });
    this.route.data.subscribe((v: any) => {
      this.readonly = v ? v.readonly : true;
    });
  }
  
  public loadData(data: any): void {
    this.engine?.geometriesData.clear();
    this.engine?.linesData.clear();
    this.parametersService.generate(data.config, data.model).then((response: any) => {
      if(!response)
        return;
      for (const c of response.components) {
        this.engine?.geometriesData.add(c.geometry as Geometry);
        
        for (const line of c.lines) {
            this.engine?.linesData.add(line as Line);
        }
      }
    });
  }

}
