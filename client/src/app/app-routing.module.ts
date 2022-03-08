import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeometryGenerationSelectionComponent } from './components/geometry-generation-selection/geometry-generation-selection.component';
import { GeometryGenerationComponent } from './components/geometry-generation/geometry-generation.component';

const routes: Routes = [
  {
    path: "geometry",
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
