import { Injectable } from '@angular/core';
import { WebGLRenderer } from 'three';
import { IRenderersProvider } from '../interfaces/i-renderers-provider';

@Injectable({
  providedIn: 'root'
})
export class RenderersProviderService implements IRenderersProvider {

  private renderers: WebGLRenderer[] = [
    new WebGLRenderer({ alpha: true, preserveDrawingBuffer: true }),
    new WebGLRenderer({ alpha: true, preserveDrawingBuffer: true }),
    new WebGLRenderer({ alpha: true, preserveDrawingBuffer: true }),
    new WebGLRenderer({ alpha: true, preserveDrawingBuffer: true }),
    new WebGLRenderer({ alpha: true, preserveDrawingBuffer: true })
  ];

  private used: WebGLRenderer[] = [];

  constructor() { }


  public get(): WebGLRenderer {
    this.ensureRenderer();
    const renderer = this.renderers.shift();
    if(!renderer) throw "Renderer not specified";
    renderer.localClippingEnabled = true;
    renderer.setClearColor(0x252627, 1);
    renderer.clear();
    renderer.autoClear = false;
    this.used.push(renderer);
    return renderer;
  }


  private ensureRenderer(): void {
    if(this.renderers.length === 0) {
      const renderer = this.used.shift();
      if(!renderer) throw "Cannot ensure rendereres";
      this.renderers.push(renderer);
    }
  }
}
