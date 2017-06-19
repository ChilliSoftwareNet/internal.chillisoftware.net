﻿import * as $ from "jquery";

export class Shared {
    header: any;
    didScroll: boolean = false;
    changeHeaderOnScrollPixels: number = 220;

    constructor(
        private $,
        private window,
        private document
    ) {
        this.header = this.$(".navbar-default");
    }

    public init = () => {
        this.initHeaderAnimation();
        this.initMenuScrollSpy();
        this.initPageScrollSmooth();
    }

    public initPageScrollSmooth = () => {
        this.$("a.page-scroll").bind("click", (event) => {
            var anchor = this.$(event.target);

            this.$('html, body').stop().animate({
                scrollTop: this.$(anchor.attr('href')).offset().top
            }, 1500, 'easeInOutExpo');

            event.preventDefault();
        });
    }

    public initMenuScrollSpy = () => {
        this.$("body").scrollspy({
            target: '.navbar-fixed-top'
        });
    }

    public initHeaderAnimation = () => {
        this.scroll();

        this.$(this.window).on("scroll", (e) => {
            if (!this.didScroll) {
                this.didScroll = true;
                setTimeout(this.scroll, 250);
            }
        });
    }

    public scroll = () => {
        let currentOffset = this.window.pageYOffset || this.document.scrollTop;

        if (currentOffset >= this.changeHeaderOnScrollPixels) {
            this.header.addClass('navbar-shrink');
        }
        else {
            this.header.removeClass('navbar-shrink');
        }

        this.didScroll = false;
    }
}

(new Shared($, window, document)).init();