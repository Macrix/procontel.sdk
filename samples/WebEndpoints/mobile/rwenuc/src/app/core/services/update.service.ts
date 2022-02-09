import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { SwUpdate, UpdateAvailableEvent } from '@angular/service-worker';

@Injectable()
export class UpdateService {
  private updateAvailable$: BehaviorSubject<UpdateAvailableEvent | null> = new BehaviorSubject<UpdateAvailableEvent | null>(null);
  public updateAvailableSubject$: Observable<UpdateAvailableEvent | null>;

  constructor(private updates: SwUpdate) {
    this.updateAvailableSubject$ = this.updateAvailable$.asObservable();
    
    if (updates.isEnabled) {
      updates.available.subscribe(event => {
        this.updateAvailable$.next(event);
      });
    }
   }

   checkForUpdate() {
    console.log('checkForUpdate')
    if (this.updates.isEnabled) {
      this.updates.checkForUpdate().then(() =>
        console.log('checkForUpdate')
      );
    }
   }

   update() {
    if (this.updates.isEnabled) {
      this.updates.checkForUpdate().then(() =>
        this.updates.activateUpdate().then(() => { 
          document.location.reload(); 
          this.updateAvailable$.next(null); 
        })
      );
    }
   }
}
