import { ModuleWithProviders } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'

import { HomeComponent } from './Components/Home/home.component'
import { AccountComponent } from './Components/Account/account.component'

import { SiteComponent } from './Components/Site/site.component'
import { SitesComponent } from './Components/Sites/sites.component'

import { SitesUserComponent } from './Components/Sites/sites-user.component'

import { SiteCreateComponent } from './Components/Sites/site-create.component'

import { UsersComponent } from './Components/Users/users.component'
import { AboutComponent } from './Components/About/about.component'

const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'account',
        component: AccountComponent
    },
    {
        path: 'site/:id',
        component: SiteComponent
    },
    {
        path: 'sites',
        component: SitesComponent
    },
    {
        path: 'sites/:id',
        component: SitesComponent
    }, 
    {
        path: 'users',
        component: UsersComponent
    },
    {
        path: 'about',
        component: AboutComponent
    },
    {
        path: 'sites-user/:id',
        component: SitesUserComponent
    },
    {
        path: 'site-create',
        component: SiteCreateComponent
    },
    {
        path: 'site-create/:id',
        component: SiteCreateComponent
    }     
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);