import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app/app.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentListComponent } from './app/student-list/student-list.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }