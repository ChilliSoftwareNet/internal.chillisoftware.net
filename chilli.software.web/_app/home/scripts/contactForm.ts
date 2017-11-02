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
            this.$("#contactForm").validate({});
        });
    }

    sendEmail = () => {
        if (this.$("#contactForm").valid()) {
            this.$.post({
                type: "POST",
                url: "/api/home/SendEmail",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    name: this.contactData.name(),
                    email: this.contactData.email(),
                    phone: this.contactData.phone(),
                    message: this.contactData.message()
                }),
                success: (response: any) => {

                }
            });
            console.log(this.contactData.name());
        }
    }
}

(new ContactForm(knockout, jquery)).init();