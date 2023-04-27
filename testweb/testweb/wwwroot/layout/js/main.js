(function ($) {
	"use strict";

	/*--
	    WOW active 
	------------------------- */
	new WOW().init();
	/*--
	    stickey menu
	------------------------- */
	var sticky = false;
	
	$(window).on('scroll resize load', function () {
		
		var scroll = $(window).scrollTop();
		
		if( scroll < $('.wrapper header').outerHeight() ) {

			if( sticky ) {

				if( $('.wrapper').hasClass('home-2') ){
					$('.main-menu-area').css('padding-top', 0);
				}
				else{
					$('.header-area').css('padding-bottom', 0);
				}

				$(".sticky-header").removeClass("sticky");
				sticky = false;
			}
		}
		else{
			
			if( !sticky ){

				if( $('.wrapper').hasClass('home-2') ){
					$('.main-menu-area').css('padding-top', $(".sticky-header").outerHeight());
				}
				else{
					$('.header-area').css('padding-bottom', $(".sticky-header").outerHeight());
				}

				$(".sticky-header").addClass("sticky");
				sticky = true;
			}
		}
	});

	/*--
	    02. jQuery MeanMenu
	------------------------- */
	$('#mobile-menu-active').meanmenu({
		meanScreenWidth: "991",
		meanMenuContainer: ".mobile-menu-area .mobile-menu",
		meanMenuClose: "×"
	});
	/*--
	    Nice Select
	------------------------- */
	$('.nice-select').niceSelect();

	/*--- Vertical-Menu Activation ----*/

	$('.categories-toggler-menu').on('click', function () {
		$('.vertical-menu-list').slideToggle();
	});
	/*---
		3. Category Menu Active
	---------------------------- */
	$('.categories-more-less').on('click', function () {
		$('.hide-child').slideToggle();
		$(this).toggleClass('rx-change');
	});
	/*--
	 owl active
	--------------------------- */
	$('.slider-active').owlCarousel({
		loop: true,
		items: 1,
		autoplay: false,
		dots: true,
		nav: false,
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.slider-active-2').owlCarousel({
		loop: true,
		items: 1,
		dots: true,
		nav: true,
		navText: ['<i class="ion-chevron-right"></i>', '<i class="ion-chevron-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
 owl active
------------------------------ */
	$('.product-h-2.priduct-module-1-active').owlCarousel({
		loop: true,
		items: 1,
		dots: false,
		nav: true,
		margin: 30,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			767: {
				items: 2
			},
			992: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.priduct-module-1-active').owlCarousel({
		loop: true,
		items: 1,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});

	/*--
	 owl active
	------------------------------ */
	$('.deals-offer-active').owlCarousel({
		loop: true,
		items: 2,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			768: {
				items: 1
			},
			992: {
				items: 2
			},
			1200: {
				items: 2
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.deals-offer-one-active').owlCarousel({
		loop: true,
		items: 2,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			768: {
				items: 1
			},
			992: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.feategory-active').owlCarousel({
		loop: true,
		items: 5,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 2
			},
			768: {
				items: 4
			},
			992: {
				items: 5
			},
			1200: {
				items: 5
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.prodict-active').owlCarousel({
		loop: true,
		items: 4,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 2
			},
			768: {
				items: 3
			},
			992: {
				items: 4
			},
			1200: {
				items: 4
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.prodict-active-4').owlCarousel({
		loop: true,
		items: 4,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 1
			},
			768: {
				items: 3
			},
			992: {
				items: 3
			},
			1200: {
				items: 3
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.prodict-two-active').owlCarousel({
		loop: true,
		items: 4,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 2
			},
			768: {
				items: 3
			},
			992: {
				items: 4
			},
			1200: {
				items: 5
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.product-three-active').owlCarousel({
		loop: true,
		items: 4,
		dots: false,
		nav: true,
		navText: ['<i class="ion-chevron-right"></i>', '<i class="ion-chevron-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 2
			},
			768: {
				items: 2
			},
			992: {
				items: 3
			},
			1200: {
				items: 4
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.brand-active').owlCarousel({
		loop: true,
		items: 1,
		margin: 15,
		dots: false,
		nav: false,
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 2
			},
			768: {
				items: 4
			},
			992: {
				items: 5
			},
			1200: {
				items: 5
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.product-category-active').owlCarousel({
		loop: true,
		items: 1,
		margin: 15,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.articles-cont-active').owlCarousel({
		loop: true,
		items: 1,
		margin: 15,
		dots: false,
		nav: false,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.single-product-active').owlCarousel({
		loop: false,
		items: 4,
		margin: 15,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 2
			},
			480: {
				items: 3
			},
			768: {
				items: 4
			},
			992: {
				items: 4
			},
			1200: {
				items: 4
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */
	$('.from-blog').owlCarousel({
		loop: true,
		items: 2,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 1
			},
			768: {
				items: 2
			},
			992: {
				items: 2
			},
			1200: {
				items: 2
			}
		},
		rtl: true
	});

	/*--
	 owl active
	------------------------------ */
	$('.post-slider').owlCarousel({
		loop: true,
		items: 1,
		dots: true,
		nav: true,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});
	/*--
	 owl active
	------------------------------ */

	$('.testimonials-active').owlCarousel({
		loop: true,
		items: 1,
		dots: false,
		nav: false,
		navText: ['<i class="fa fa-angle-right"></i>', '<i class="fa fa-angle-left"></i>'],
		responsive: {
			0: {
				items: 1
			},
			600: {
				items: 1
			},
			1000: {
				items: 1
			},
			1200: {
				items: 1
			}
		},
		rtl: true
	});


	/*--
	    elevateZoom
	------------------------------ */
	$("#zoom1").elevateZoom({
		gallery: 'gallery_01',
		responsive: true,
		zoomType: 'inner',
		cursor: 'crosshair'
	});



	/*--
	  11. price-slider active
	-----------------------------*/
	$("#price-slider").slider({
		range: true,
		min: 50000,
		max: 1450000,
		values: [240000, 1050000],
		step: 5000,
		slide: function (event, ui) {
			$("#min-price-text").html(ui.values[0] + ' تومان');
			$("#max-price-text").html(ui.values[1] + ' تومان');
			$("#min-price").val(ui.values[0]);
			$("#max-price").val(ui.values[1]);
		}
	});
	$("#min-price-text").html($("#price-slider").slider("values", 0) + ' تومان');
	$("#max-price-text").html($("#price-slider").slider("values", 1) + ' تومان');
	$("#min-price").val($("#price-slider").slider("values", 0));
	$("#max-price").val($("#price-slider").slider("values", 1));




	/*---
	    select last tab 
	-------------------------*/

	$('.tabs-categorys-list a[href="#new-arrivals"],.shop-item-filter-list a[href="#grid"],.discription-tab-menu a[href="#description"]').tab('show')

	/*--
		Count Down Timer
	----------------------------*/
	$('[data-countdown]').each(function () {
		var $this = $(this),
			finalDate = $(this).data('countdown');
		$this.countdown(finalDate, function (event) {
			$this.html(event.strftime('<span class="cdown day"><span class="time-count">%-D</span> <p>روز</p></span> <span class="cdown hour"><span class="time-count">%-H</span> <p>ساعت</p></span> <span class="cdown minutes"><span class="time-count">%M</span> <p>دقیقه</p></span> <span class="cdown second"><span class="time-count">%S</span> <p>ثانیه</p></span>'));
		});
	});


	/*--
	  Vertical-Menu Activation
	-----------------------------*/
	$('.categorie-title,.mobile-categorei-menu').on('click', function () {
		$('.vertical-menu-list,.mobile-categorei-menu-list').slideToggle();
	});

	/*--
	  Category menu Activation
	------------------------------*/
	$('#cate-toggle li.has-sub>a,#cate-mobile-toggle li.has-sub>a').on('click', function () {
		$(this).removeAttr('href');
		var element = $(this).parent('li');
		if (element.hasClass('open')) {
			element.removeClass('open');
			element.find('li').removeClass('open');
			element.find('ul').slideUp();
		} else {
			element.addClass('open');
			element.children('ul').slideDown();
			element.siblings('li').children('ul').slideUp();
			element.siblings('li').removeClass('open');
			element.siblings('li').find('li').removeClass('open');
			element.siblings('li').find('ul').slideUp();
		}
	});

	/*--
	    Accordion
	-------------------------*/
	$(".frequently-accordion").collapse({
		accordion: true,
		open: function () {
			this.slideDown(300);
		},
		close: function () {
			this.slideUp(300);
		}
	});

	/*--
	  showlogin toggle function
	--------------------------*/
	$('#showlogin').on('click', function () {
		$('#checkout-login').slideToggle(500);
	});

	/*--
	  showcoupon toggle function
	--------------------------*/
	$('#showcoupon').on('click', function () {
		$('#checkout-coupon').slideToggle(500);
	});

	/*--- Checkout ---*/
	$("#chekout-box").on("change", function () {
		$(".account-create").slideToggle("100");
	});

	/*-- Checkout -----*/
	$("#chekout-box-2").on("change", function () {
		$(".ship-box-info").slideToggle("100");
	});


	/*--
	    ScrollUp Active
	-----------------------------------*/
	$.scrollUp({
		scrollText: '<i class="ion-chevron-up"></i>',
		easingType: 'linear',
		scrollSpeed: 900,
		animation: 'fade'
	});
	
	
	/*--
	    Instafeed
	-----------------------------------------*/
	if ($('#instagram-feed').length) {
		var feed = new Instafeed({
			get: 'user',
			userId: 6665768655,
			accessToken: '6665768655.1677ed0.313e6c96807c45d8900b4f680650dee5',
			target: 'instagram-feed',
			resolution: 'thumbnail',
			limit: 6,
			template: '<li><a href="{{link}}" target="_new"><img src="{{image}}" /></a></li>',
		});
		feed.run();
	}


	/*--
	    Shop sidebar checkboxes
	-----------------------------------------*/
	$('.sidebar-categores-box .filter-group a').click(function(e){
		e.preventDefault();
		$(this).toggleClass('active');
	});
	

	/*--
	    Prevent large image click jump
	-----------------------------------------*/
	$('#img-1 > a').click(function(e){
		e.preventDefault();
	});


})(jQuery);