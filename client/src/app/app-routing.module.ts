import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { GeometryGenerationSelectionComponent } from './components/geometry-generation-selection/geometry-generation-selection.component';
import { GeometryGenerationComponent } from './components/geometry-generation/geometry-generation.component';
import { SamplesContainerComponent } from './components/samples-container/samples-container.component';

const routes: Routes = [
  {
    path: "geometry/:id",
    component: GeometryGenerationSelectionComponent,
    children: [
      {
        path: "preview",
        component: GeometryGenerationComponent,
        data: {readonly: true}
      },
      {
        path: "edit",
        component: GeometryGenerationComponent,
        data: {readonly: false}
      }
    ]
  },
  {
    path: "samples",
    component: SamplesContainerComponent
  },
  { path: '', redirectTo: 'samples', pathMatch: 'full' },
  { path: '**', redirectTo: 'samples', pathMatch: 'full' }
];

export const routingConfiguration: ExtraOptions = {
  paramsInheritanceStrategy: 'always'
};

@NgModule({
  imports: [RouterModule.forRoot(routes, routingConfiguration)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
