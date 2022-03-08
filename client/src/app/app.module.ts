import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewerComponent } from './components/viewer/viewer.component';
import {HttpClientModule} from '@angular/common/http';
import { ParameterSelectorComponent } from './components/parameter-selector/parameter-selector.component';
import { ParameterModelComponent } from './components/parameter-model/parameter-model.component';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule  } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { GeometryGenerationComponent } from './components/geometry-generation/geometry-generation.component';
import { GeometryGenerationSelectionComponent } from './components/geometry-generation-selection/geometry-generation-selection.component';

@NgModule({
  declarations: [
    AppComponent,
    ViewerComponent,
    ParameterSelectorComponent,
    ParameterModelComponent,
    GeometryGenerationComponent,
    GeometryGenerationSelectionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatButtonModule,
    FormsModule,
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
