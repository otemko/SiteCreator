import { NgModule }      from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent }   from "./app.component";
import { HttpModule } from "@angular/http";
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { AutoCompleteModule } from 'primeng/primeng';
import { DndModule } from "ng2-dnd";
import { FroalaModule } from "./Froala-editor/froala.module";
import { DynamicComponentModule } from "angular2-dynamic-component";
import { Ng2PaginationModule } from 'ng2-pagination';

import { FormsModule }   from "@angular/forms";

import { HomeComponent } from "./Components/Home/home.component";
import { LastCreatedSitesComponent } from "./Components/Home/Parts/last-created-sites.component";
import { MostCommentedPages } from "./Components/Home/Parts/most-commented-pages.component";
import { MostRatedPages } from "./Components/Home/Parts/most-rated-pages.component";

import { AccountComponent } from "./Components/Account/account.component";

import { SiteComponent } from "./Components/Site/site.component";
import { SitesComponent } from "./Components/Sites/sites.component";
import { SiteItemComponent } from "./Components/Sites/site-item.component";

import { SitesUserComponent } from "./Components/Sites/sites-user.component";
import { SiteUserItemComponent } from "./Components/Sites/site-user-item.component";

import { UsersComponent } from "./Components/Users/users.component";
import { UsersItemComponent } from "./Components/Users/users-item.component";


import { AboutComponent } from "./Components/About/about.component";
import { AccountHeaderComponent } from "./Components/Account/AccountPanel/accountPanel.component";
import { LanguagePanelComponent } from "./Components/LanguagePanel/languagePanel.component";

import { SiteCreateComponent } from "./Components/Sites/site-create.component";
import { PageItemComponent } from "./Components/Site/page-item.component";

import { PageEditorComponent } from './Components/Page/page.editor.component';
import { PageComponent } from './Components/Page/page.component';

import { SearchComponent } from './Components/Search/search.component'
import { LockoutComponent } from './Components/Lockout/lockout.component'

import { CommentComponent } from './Components/Comments/comments.component'
import { CommentItemComponent } from './Components/Comments/comment-item.component'


import { routing } from './routes';

@NgModule({
    imports: [
        BrowserModule,
        routing,
        HttpModule,
        DndModule.forRoot(),
        FormsModule,
        FroalaModule,
        DynamicComponentModule,
        AutoCompleteModule,
        Ng2PaginationModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        AccountComponent,
        SiteComponent,
        SitesComponent,
        UsersComponent,
        UsersItemComponent,
        AboutComponent,
        SiteItemComponent,
        AccountHeaderComponent,
        LanguagePanelComponent,
        SitesUserComponent,
        SiteUserItemComponent,
        SiteCreateComponent,
        SearchComponent,
        PageEditorComponent,
        PageComponent,
        PageItemComponent,
        CommentComponent,
        CommentItemComponent,
        LockoutComponent,
        LastCreatedSitesComponent,
        MostCommentedPages,
        MostRatedPages
    ],
    providers: [
        { provide: LocationStrategy, useClass: HashLocationStrategy},
    ],
    bootstrap: [AppComponent],
})
export class AppModule { }