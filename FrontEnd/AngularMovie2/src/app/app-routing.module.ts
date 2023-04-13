import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';

import { ProfileComponent } from './components/Content/profile/profile.component';
import { EditProfileComponent } from './components/Content/Profile-content/edit-profile/edit-profile.component';
import { MyprofileComponent } from './components/Content/Profile-content/myprofile/myprofile.component';
import { MyHistoryComponent } from './components/Content/Profile-content/my-history/my-history.component';
import { MovieDetailsComponent } from './components/Content/movies/movie-details/movie-details.component';
import { MovieTicketComponent } from './components/Content/movies/movie-ticket/movie-ticket.component';
import { BookingNavComponent } from './components/Content/movies/movie-ticket/booking-nav/booking-nav.component';
import { TicketComponent } from './components/Content/movies/movie-ticket/bookingNav/ticket/ticket.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
{path:'home', component:HomeComponent},
{path:'',redirectTo: 'home', pathMatch:'full'},
{path:"login",component:LoginComponent},
{path:'register',component:RegisterComponent},
{path:'profile',component:ProfileComponent,canActivate:[AuthGuard],children:[

    {path:'myprofile',component:MyprofileComponent,outlet:'profile-content'},
    {path:'edit-profile',component:EditProfileComponent,outlet:'profile-content'},
    {path:'my-history',component:MyHistoryComponent,outlet:'profile-content'},
    {path:'',redirectTo:'/profile/(profile-content:myprofile)',pathMatch:'full'}

]},
{path: 'movie/:id',component:MovieDetailsComponent},
{path: 'movie/:movieID/show/:showID',component:MovieTicketComponent},
{path: 'movie/:movieID/show/:showID/booking/:bookingID/ticket/:ticketID',component:BookingNavComponent},
{path: 'movieticket/:paymentID',component:TicketComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{onSameUrlNavigation:'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
