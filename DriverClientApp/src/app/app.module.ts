import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { EditService, FilterService, ForeignKeyService, FreezeService, GridModule, GroupService, PageService, ResizeService, SelectionService, SortService, ToolbarService } from '@syncfusion/ej2-angular-grids';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DriverService } from './driver.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    GridModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

  ],
  providers: [
    DriverService,
    PageService,
    SortService,
    FilterService,
    GroupService,
    ResizeService,
    ToolbarService,
    EditService,
    FreezeService, SelectionService,
    ForeignKeyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
