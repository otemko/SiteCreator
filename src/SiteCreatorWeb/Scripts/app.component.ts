﻿import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'my-app',
    templateUrl: './appScripts/app.component.html',
    styleUrls: ['./appScripts/app.component.css']
})
export class AppComponent implements OnInit {

    constructor(public location: Location) { }

    ngOnInit() {
        this.location.go('/');
    }
 }