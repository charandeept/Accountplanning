import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './@core';
import { RoleGuard } from './@core/guards/role.guard';
import { AddOpportunityComponent } from './opportunities/add-opportunity/add-opportunity.component';
import { CompaniesListComponent } from './companies-list/companies-list.component';
import { ImportUsersComponent } from './companies-list/import-users/import-users.component';
import { CustomerInfoComponent } from './customer-info/customer-info.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './login/login.component';
import { SsoCallbackComponent } from './login/sso-callback/sso-callback.component';
import { OpportunitiesComponent } from './opportunities/opportunities.component';
import { EditHierarchyComponent } from './org-hierarchy/edit-hierarchy/edit-hierarchy.component';
import { OrgHierarchyComponent } from './org-hierarchy/org-hierarchy.component';
import { EnablersComponent } from './enablers/enablers.component';
import { ErrorComponent } from './shared';

const routes: Routes = [
 
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },

  {
    path: 'sso-callback',
    component: SsoCallbackComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '',
    component: LayoutComponent,
    //canActivate: [AuthGuardService],
    children: [{
      path: 'home',
      loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    }]
  },  
  {
    path: '',
    component: LayoutComponent,
    children: [{
      path: 'account-info/:id',
      loadChildren: () => import('./customer-info/customer-info.module').then(m => m.CustomerInfoModule),canActivate:[AuthGuardService]
    }]
  },
  {
    path:'',
    component: LayoutComponent,
    children: [{
      path:'org-hierarchy',
      component: OrgHierarchyComponent,
      loadChildren: ()=> import('./org-hierarchy/org-hierarchy.module').then(m=>m.OrgHierarchyModule),canActivate:[AuthGuardService]
    }]
  },
  {
    path:'org-hierarchy',
    component: LayoutComponent,
    children: [{
      path:'edit-hierarchy',
      component: EditHierarchyComponent,
      loadChildren: ()=> import('./org-hierarchy/edit-hierarchy/edit-hierarchy.module').then(m=>m.EditHierarchyModule),canActivate:[AuthGuardService]
    }]
  },
  {
    path:'',
    component: LayoutComponent,
    children: [{
      path:'dashboard',
      component: DashboardComponent,
      loadChildren: ()=> import('./dashboard/dashboard.module').then(m=>m.DashboardModule),canActivate:[RoleGuard , AuthGuardService]
    }]
  },
  {
    path:'',
    component: LayoutComponent,
    children: [{
      path:'opportunities',
      component: OpportunitiesComponent,
      loadChildren: ()=> import('./opportunities/opportunities.module').then(m=>m.OpportunitiesModule),canActivate:[AuthGuardService]
    }]
  },
  {
    path:'',
    component: LayoutComponent,
    children: [{
      path:'companies-list',
      component: CompaniesListComponent,
      loadChildren: ()=> import('./companies-list/companies-list.module').then(m=>m.CompaniesListModule)
    }]
  },
  {
    path:'companies-list',
    component: LayoutComponent,
    children: [{
      path:'import-users',
      component: ImportUsersComponent,
      loadChildren: ()=> import('./companies-list/import-users/import-users.module').then(m=>m.ImportUsersModule),

    }]
  },
  {
    path:'',
    component: LayoutComponent,
    children: [{
      path:'add-opportunity',
      component: AddOpportunityComponent,
      loadChildren: ()=> import('./opportunities/add-opportunity/add-opportunity.module').then(m=>m.AddOpportunityModule),canActivate:[AuthGuardService]
    }]
  },
  {
    path:'',
    component: LayoutComponent,
    children: [{
      path:'enablers',
      component: EnablersComponent,
      loadChildren: ()=> import('./enablers/enablers.module').then(m=>m.EnablersModule),canActivate:[AuthGuardService]
    }]
  },
  { path: 'error', component: ErrorComponent },
  //This should be at the bottom only
  { path: '**', redirectTo: '/error' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
