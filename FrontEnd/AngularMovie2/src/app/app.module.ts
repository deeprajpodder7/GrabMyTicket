import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RegisterComponent } from './components/register/register.component';
import { AboutComponent } from './components/Content/about/about.component';
import { MoviesComponent } from './components/Content/movies/movies.component';
import { ProfileComponent } from './components/Content/profile/profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MovieDetailsComponent } from './components/Content/movies/movie-details/movie-details.component';
import { MovieTicketComponent } from './components/Content/movies/movie-ticket/movie-ticket.component';
import {MatTableModule} from '@angular/material/table';
import {MatSelectModule} from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatCardModule} from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { QRCodeModule } from 'angularx-qrcode';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookingNavComponent } from './components/Content/movies/movie-ticket/booking-nav/booking-nav.component';
import { TicketComponent } from './components/Content/movies/movie-ticket/bookingNav/ticket/ticket.component';
import { EditProfileComponent } from './components/Content/Profile-content/edit-profile/edit-profile.component';
import { MyHistoryComponent } from './components/Content/Profile-content/my-history/my-history.component';
import { MyprofileComponent } from './components/Content/Profile-content/myprofile/myprofile.component';
import { AuthGuard } from './guards/auth.guard';
import { ErrorInterceptor } from './guards/error.interceptor';
import { JwtInterceptor } from './guards/jwt.interceptor';
import {MatChipsModule} from '@angular/material/chips';
import { PasswordFieldComponent } from './components/password-field/password-field.component'; 


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    ProfileComponent,
    AboutComponent,
    NavbarComponent,
    MoviesComponent,
    MovieDetailsComponent,
    MovieTicketComponent,
    BookingNavComponent,
    TicketComponent,
    EditProfileComponent,
    MyHistoryComponent,
    MyprofileComponent,
    PasswordFieldComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatSnackBarModule,
    MatCardModule,
    QRCodeModule,
    MatTableModule,
    MatChipsModule
  ],
  providers: [{provide:HTTP_INTERCEPTORS,useClass:
    JwtInterceptor,multi:true},
    {provide:HTTP_INTERCEPTORS,useClass:
      ErrorInterceptor,multi:true},
    AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
