import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from '../_models/user';

//Injectable decorator - znači da se ovaj servis može injektirati u druge komponente ili čak druge servise.
@Injectable({
  //U novoj verziji ne mora se eksplicitno navoditi. Kada se jenom instancira ostaje sve do kraja (zatvaranje browsera) - Singleton
  providedIn: 'root'
})
export class AccountService {
  baseUrl='https://localhost:5001/api/';

  //Buffer za pohranu (1)-znači da se pohranjuje jedna vrijednost u observable.
  private currentUserSource= new ReplaySubject<User>(1);  
  currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) { }

  login(model: any){
    //RxJS - ovo je naš observable. Na ovo se prijavljujem kod logiranja gdje se sprema user u local storage u browseru
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if(user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      } 
      )
    )
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  //Kod logouta makni usera iz local storage browsera
  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
