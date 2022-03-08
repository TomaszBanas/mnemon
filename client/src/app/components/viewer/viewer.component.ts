import { AfterViewInit, Component, ElementRef, Input, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { IEngine } from 'src/app/interfaces/i-engine';

@Component({
  selector: 'viewer',
  templateUrl: './viewer.component.html',
  styleUrls: ['./viewer.component.scss']
})
export class ViewerComponent implements OnInit, AfterViewInit, OnDestroy {

  @Input() set engine(value: IEngine) {
    if(this._engine)
      this._engine.setCanvasContainer(undefined);
    this._engine = value;
    if(this.isViewInit)
      this._engine.setCanvasContainer(this.canvasContainer);
  }
  @ViewChild('canvasContainer') canvasContainer!: ElementRef;


  private size: {width: number, height: number} = {width: 0, height: 0};
  private sizeSubscription!: Subscription;
  private _engine: IEngine | undefined = undefined;
  private isViewInit: boolean = false;
  constructor(private zone: NgZone) {

  }

  ngOnInit(): void { }
  ngAfterViewInit(): void {
    this.isViewInit = true;
    this._engine?.setCanvasContainer(this.canvasContainer);
    this.sizeSubscription = this.zone.onStable.asObservable().subscribe(this.checkResize.bind(this));
  }
  ngOnDestroy() : void {
    this._engine?.setCanvasContainer(undefined);
    this.sizeSubscription.unsubscribe();
  }


  public checkResize(): void {
    const data = this.canvasContainer.nativeElement.getBoundingClientRect();
    if(data.width != this.size.width || 
      data.height != this.size.height) {
        this.size.width = data.width;
        this.size.height = data.height;
        this._engine?.updateCanvasSize(this.size.width, this.size.height);
      }
  }
}
