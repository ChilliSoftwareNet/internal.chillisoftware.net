import * as knockout from "knockout";
import * as jquery from "jquery";
import "jquery-validation";

class ContactForm {
    contactData: any;

    constructor(
        private readonly ko,
        private readonly $) {

        this.contactData = {
            name: this.ko.observable(),
            email: this.ko.observable(),
            phone: this.ko.observable(),
            message: this.ko.observable(),
            sendEmail: this.sendEmail
        }
    }

    init = () => {
        this.$("document").ready(() => {
            this.ko.applyBindings(this.contactData);
        });
    }

    sendEmail = () => {
        if (this.$("#contactForm").valid()) {
            console.log(this.contactData.name());
        }
    }
}

(new ContactForm(knockout, jquery)).init();