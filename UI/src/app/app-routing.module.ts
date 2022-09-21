import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEventComponent } from './add-event/add-event.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { LoginComponent } from './login/login.component';
import { RegisteredEventsComponent } from './registered-events/registered-events.component';
import { SignupComponent } from './signup/signup.component';
import { UpdateEventComponent } from './update-event/update-event.component';
import { UserHomeComponent } from './user-home/user-home.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  {path: 'adminHome', component:AdminHomeComponent},
  {path: 'userHome', component:UserHomeComponent},
  {path: 'updateEvent/:eventId', component:UpdateEventComponent},
  {path: 'registeredEvent', component:RegisteredEventsComponent},
  {path: 'addEvent', component:AddEventComponent},
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
