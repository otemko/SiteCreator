import { ModuleWithProviders } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'

import { HomeComponent } from './Components/Home/home.component'
import { AccountComponent } from './Components/Account/account.component'
import { SiteComponent } from './Components/Site/site.component'
import { SitesComponent } from './Components/Sites/sites.component'
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
        path: 'users',
        component: UsersComponent
    },
    {
        path: 'about',
        component: AboutComponent
    },
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);