import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }   from './app.component';
import { HttpModule } from '@angular/http';
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';

import { HomeComponent } from './Components/Home/home.component'
import { AccountComponent } from './Components/Account/account.component'

import { SiteComponent } from './Components/Site/site.component'
import { SitesComponent } from './Components/Sites/sites.component'
import { SiteItemComponent } from './Components/Sites/site-item.component'

import { SitesUserComponent } from './Components/Sites/sites-user.component'
import { SiteUserItemComponent } from './Components/Sites/site-user-item.component'

import { UsersComponent } from './Components/Users/users.component'
import { AboutComponent } from './Components/About/about.component'
import { LoginComponent } from './Components/Account/Login/login.component'


import { routing } from './routes';

@NgModule({
    imports: [
        BrowserModule,
        routing,
        HttpModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        AccountComponent,
        SiteComponent,
        SitesComponent,
        UsersComponent,
        AboutComponent,
        LoginComponent,
        SiteItemComponent
        ,
        SitesUserComponent,
        SiteUserItemComponent
    ],
    providers: [
        { provide: LocationStrategy, useClass: HashLocationStrategy },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }