import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import { AngularMaterialModule } from './angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import {NgxPaginationModule} from 'ngx-pagination';
import { SoGDComponent } from './so-gd/so-gd.component';
import { AuthGuard } from './guards/auth-guard.service';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ThisinhComponent } from './thisinh/thisinh.component';
import { DiemComponent } from './diem/diem.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { FooterComponent } from './footer/footer.component';
export function tokenGetter() {
  return localStorage.getItem("jwt");
}
@NgModule({
  declarations: [
    FooterComponent,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SoGDComponent,
    LoginComponent,
    ThisinhComponent,
    DiemComponent
  ],
  imports: [
    GoogleChartsModule,
    FlexLayoutModule,
    ReactiveFormsModule ,
    BrowserAnimationsModule,
    AngularMaterialModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'sogd', component: SoGDComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'thisinh/:id', component: ThisinhComponent,canActivate: [AuthGuard] },
      { path: 'thisinh', component: ThisinhComponent,canActivate: [AuthGuard] },
      { path: 'diem/:id/:kt', component: DiemComponent,canActivate: [AuthGuard] },
      { path: 'diem', component: DiemComponent,canActivate: [AuthGuard] },
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["https://localhost:44394"],
        blacklistedRoutes: []
      }
    }),
    BrowserAnimationsModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
