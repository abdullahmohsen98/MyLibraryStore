import { Component, OnInit, OnDestroy,  ElementRef, ViewChild } from '@angular/core';
import { Order } from 'src/app/models/order';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { CheckoutService } from 'src/app/services/checkout.service';
import { ShoppingCart } from 'src/app/models/shoppingcart';
import { SnackbarService } from 'src/app/services/snackbar.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SubscriptionService } from 'src/app/services/subscription.service';
declare var paypal;
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit, OnDestroy {
  @ViewChild('paypal') paypalElement: ElementRef;
  planId: any;
  subcripId: any;
  basicAuth = 'Basic QWNWUTBIX05QTVlWMDIzSDhMM3Y2alhNcDRVdaUN2V0M4Mmo4a19hodjdkdS14M3F4dFJ6Y2pNTnRPcGN6OUpPdjU1TW9jTllsEV1p5WURWNm46RUZJRWtJd0dYdDFJSTdFRmlEdVQ3UWExV2ZXWDZnYmw3Z2w5ajgwZVlsVjI1ODdfUTRHSUxCSWxZfOGg1SzRRZTFhMZU1yVgFZGRThIWXAyRjA=';
   //Pass your ClientId + scret key
  userId;
  totalPrice: number;
  checkOutItems = new Order();
  private unsubscribe$ = new Subject<void>();

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private cartService: CartService,
    private checkOutService: CheckoutService,
    private snackBarService: SnackbarService,
    private subscriptionService: SubscriptionService) {
    this.userId = localStorage.getItem('userId');
  }

  checkOutForm = this.fb.group({
    name: ['', Validators.required],
    addressLine: ['', Validators.required],
    phoneNumber: ['',Validators.compose([Validators.required, Validators.pattern('^01[0-2,5]{1}[0-9]{8}$')])],
    // addressLine2: ['',],
    ZIPcode: ['', Validators.compose([Validators.required, Validators.pattern('^[1-9][0-9]{4}$')])],
    state: ['', [Validators.required]]
  });

  get name() {
    return this.checkOutForm.get('name');
  }

  get addressLine() {
    return this.checkOutForm.get('addressLine');
  }

  get phoneNumber() {
    return this.checkOutForm.get('phoneNumber');
  }

  // get addressLine2() {
  //   return this.checkOutForm.get('addressLine2');
  // }

  get ZIPcode() {
    return this.checkOutForm.get('ZIPcode');
  }
  get state() {
    return this.checkOutForm.get('state');
  }

  ngOnInit() {
    this.getCheckOutItems();


    const self = this;
    this.planId = 'P-20D52460DL479523BLV56M5Y';  //Default Plan Id
    paypal.Buttons({
      createSubscription: function (data, actions) {
        return actions.subscription.create({
          'plan_id': self.planId,
        });
      },
      onApprove: function (data, actions) {
        console.log(data);
        alert('You have successfully created subscription ' + data.subscriptionID);
        self.getSubcriptionDetails(data.subscriptionID);
      },
      onCancel: function (data) {
        // Show a cancel page, or return to cart
        console.log(data);
      },
      onError: function (err) {
        // Show an error page here, when an error occurs
        console.log(err);
      }

    }).render(this.paypalElement.nativeElement);

  }
  getSubcriptionDetails(subcriptionId) {
    const xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
        console.log(JSON.parse(this.responseText));
        alert(JSON.stringify(this.responseText));
      }
    };
    xhttp.open('GET', 'https://api.sandbox.paypal.com/v1/billing/subscriptions/' + subcriptionId, true);
    xhttp.setRequestHeader('Authorization', this.basicAuth);

    xhttp.send();
  }
  // ============END Get Subcription Details Method========================

  getCheckOutItems() {
    this.cartService.getCartItems(this.userId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (result: ShoppingCart[]) => {
          this.checkOutItems.orderDetails = result;
          this.getTotalPrice();
        }, error => {
          console.log('Error ocurred while fetching shopping cart item : ', error);
        });
  }

  getTotalPrice() {
    this.totalPrice = 0;
    this.checkOutItems.orderDetails.forEach(item => {
      this.totalPrice += (item.book.price * item.quantity);
    });
    this.checkOutItems.cartTotal = this.totalPrice;
  }

  placeOrder() {
    if (this.checkOutForm.valid) {
      this.checkOutService.placeOrder(this.userId, this.checkOutItems)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe(
          result => {
            this.subscriptionService.cartItemcount$.next(result);
            this.router.navigate(['/myorders']);
            this.snackBarService.showSnackBar('Order placed successfully!!!');
          }, error => {
            console.log('Error ocurred while placing order : ', error);
          });
    }
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  stringOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return true;
    }
    return false;

  }
}
