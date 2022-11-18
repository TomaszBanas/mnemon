import { Component, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomOrthographicCamera } from 'src/app/cameras/orthographic-camera';
import { Geometry } from 'src/app/implementations/shared/models/geometry';
import { Grid } from 'src/app/implementations/shared/models/grid';
import { Line } from 'src/app/implementations/shared/models/line';
import { Vector } from 'src/app/implementations/shared/models/vector';
import { TestEngine } from 'src/app/implementations/test1/engine/test-engine';
import { MainModel } from 'src/app/implementations/test1/models/main-model';
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
  public sampleId?: string | null;
  public readonly!: boolean;
  
  public interval!: any;

  constructor(
    private renderersProvider: RenderersProviderService,
    private parametersService: ParametersService,
    private zone: NgZone,
    private route: ActivatedRoute
    ) {
    const renderer = this.renderersProvider.get();
    this.engine = new TestEngine(renderer);
    this.camera = new CustomOrthographicCamera();
    this.engine.setCamera(this.camera);

    this.engine.render();
    (window as any)["testProxy"] = this.engine;
  }

  ngOnInit() {
    this.route.params.subscribe(paramMap => {
      this.zone.run(() => {
        this.selectedConfig = paramMap['id'];
      });
    });
    this.route.queryParamMap.subscribe(paramMap => {
      this.zone.run(() => {
        this.sampleId = paramMap.get('sampleId');
      });
    });
    this.route.data.subscribe((v: any) => {
      this.readonly = v ? v.readonly : true;
    });
  }
  
  public loadData(data: any): void {
    this.engine?.clearModels();
    this.parametersService.generate(data.config, data.model).then((response: any) => {
      if(!response)
        return;
      this.engine?.updateModels(response.components.map((x: any) => x as MainModel));
    });
  }
  public clear(): void {
    this.engine?.clearModels();
  }
  public picture(): void {
    this.engine?.picture();
  }

}
