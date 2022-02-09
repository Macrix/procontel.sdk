import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Exception } from '@zxing/library';
import { ZXingScannerComponent } from '@zxing/ngx-scanner';
import { BehaviorSubject, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';

export interface QrScannerComponentModel {
  expected: string;
}

@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.component.html',
  styleUrls: ['./qr-scanner.component.scss']
})
export class QrScannerComponent implements OnInit {
  //https://medium.com/swlh/scanning-barcode-or-qr-code-in-an-angular-app-with-zxing-9d3c8dfd5b96
  //https://github.com/zxing-js/ngx-scanner/blob/master/projects/zxing-scanner-demo/src/app/

  availableDevices: MediaDeviceInfo[] = [];
  deviceCurrent: MediaDeviceInfo | undefined = undefined;
  deviceSelected: string = '';

  cameraReady$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  hasPermission: boolean = false;

  scanErrorMessage: string = '';

  torchEnabled = false;
  torchAvailable$ = new BehaviorSubject<boolean>(false);
  tryHarder = false;
  
  @ViewChild("scanner") scanner: ZXingScannerComponent | undefined = undefined;
  private ngUnsubscribe = new Subject(); 
  
  readByScanner: string | undefined = undefined;

  constructor(protected mdDialogRef: MatDialogRef<QrScannerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: QrScannerComponentModel) { }

  
  ngOnInit(): void {
  }
  
  ngAfterViewInit(): void {
    console.log("ngAfterViewInit", this.scanner); 
    this.scanner!.camerasFound
      .pipe(
        map(x => x.length > 0),
        tap(x => this.cameraReady$.next(x)),
        takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        console.log("ngAfterViewInit::camerasFound", this.scanner); 
      });
  }

  close() {
    this.mdDialogRef.close();
  }
  confirm() {
    this.mdDialogRef.close(this.readByScanner)
  }

  _textValue: string = ''; 
  get textValue() : string {
    return this._textValue
  }
  set textValue(val: string) {
    this.onCodeResult(val);  
  }

  onCodeResult(resultString: string) {
    if (resultString && resultString == this.data.expected) {
      this.readByScanner = resultString;
      this.scanErrorMessage = '';
    } else {
      this.readByScanner = undefined;
      this.scanErrorMessage = "Unexpected string has been read.";
    }
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next(null);
    this.ngUnsubscribe.complete();
    
    console.log("ngOnDestroy", this.scanner);
    if (this.scanner!.autostarting) {
      this.scanner!.scanStop();
    }    
  }  

  onScanFailure(reason?: Exception) {
    if (reason) {
      this.scanErrorMessage = reason.message;
    }
  }

  onScanError(error: any) {
    this.scanErrorMessage = error;
  }

  onDeviceSelectChange(selected: string) {
    const selectedStr = selected || '';
    if (this.deviceSelected === selectedStr) { return; }
    this.deviceSelected = selectedStr;
    const device = this.availableDevices.find(x => x.deviceId === selected);
    this.deviceCurrent = device || undefined;
  }

  onDeviceChange(device: MediaDeviceInfo) {
    const selectedStr = device?.deviceId || '';
    if (this.deviceSelected === selectedStr) { return; }
    this.deviceSelected = selectedStr;
    this.deviceCurrent = device || undefined;
  }

  onHasPermission(has: boolean) {
    this.hasPermission = has;
  }

  onTorchCompatible(isCompatible: boolean): void {
    this.torchAvailable$.next(isCompatible || false);
  }

  toggleTorch(): void {
    this.torchEnabled = !this.torchEnabled;
  }

  toggleTryHarder(): void {
    this.tryHarder = !this.tryHarder;
  }
}
