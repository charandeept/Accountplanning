import { Component,OnInit } from "@angular/core";

@Component({
    selector: 'app-org-hierarchy-hover-view',
    templateUrl: './org-hierarchy-hover-view.component.html',
    styleUrls: ['./org-hierarchy-hover-view.component.scss']
  })
  
  export class OrgHierarchyHoverViewComponent implements OnInit {
    
    user: any;
    styleLeft: any;
    styleTop: any;
    
    constructor(){}
    ngOnInit(): void {
      
    }
  }