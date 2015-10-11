jQuery(function ($) {

	/*==========  show/hide navigation  ==========*/
	$(".menu-trigger").on('click', function(){
		$(".nav-menu").fadeIn(300);
	});

	$(".dismiss-button").on('click', function(){
		$(".nav-menu").slideUp(300);
	});



	/*==========  main-slider  ==========*/
	var slideHeight = $(window).height();
	$('#home-slider .item').css('height',slideHeight);

	$(window).resize(function(){'use strict',
		$('#home-slider .item').css('height',slideHeight);
	});



	/*==========  Scroll Menu  ==========*/
	$(window).on('scroll', function(){
		if( $(window).scrollTop()>slideHeight ){
			$('.main-nav').addClass('main-nav-change');
		} else {
			$('.main-nav').removeClass('main-nav-change');
		}
	});



	/*==========  Progress Bar  ==========*/
	$('#our-skills').bind('inview', function(event, visible, visiblePartX, visiblePartY) {
		if (visible) {
			$.each($('div.progress-bar'),function(){
				$(this).css('width', $(this).attr('data-valuetransitiongoal')+'%');
			});
			$(this).unbind('inview');
		}
	});



	/*==========  Initiat WOW JS  ==========*/
	new WOW().init();



	/*==========  client feedback   ==========*/
	$(document).ready(function () {
	  
	    var carousel = $("#client-feedback");
	  
	    carousel.owlCarousel({
	   	navigation:true,
	    navigationText: [
	      "<i class='fa-angle-left icon-nav'></i>",
	      "<i class='fa-angle-right icon-nav'></i>"
	      ],
	    itemsCustom: [
	      [0,3]
	    ],
	     afterAction: function(el){
	       //remove class active
	       this
	       .$owlItems
	       .removeClass('active')
	      
	       //add class active
	       this
	       .$owlItems //owl internal $ object containing items
	       .eq(this.currentItem + 1)
	       .addClass('active')
	      
	     }
	     
	    });	  
	});



	/*==========  animate.css on hover  ==========*/
	function animationHover(element, animation){
		element = $(element);
		element.hover(
			function() {
				element.addClass('animated ' + animation);        
			},
			function(){
            //wait for animation to finish before removing classes
            window.setTimeout( function(){
            	element.removeClass('animated ' + animation);
            }, 2000);         
        });
	}



	/*==========  Countdown  ==========*/
	$('#count-down').bind('inview', function(event, visible, visiblePartX, visiblePartY) {
		if (visible) {
			$(this).find('.counter').each(function () {
				var $this = $(this);
				$({ Counter: 0 }).animate({ Counter: $this.text() }, {
					duration: 2000,
					easing: 'swing',
					step: function () {
						$this.text(Math.ceil(this.Counter));
					}
				});
			});
			$(this).unbind('inview');
		}
	});


	/*==========  isotope  ==========*/
	$(window).load(function(){'use strict';
		var $portfolio_selectors = $('.work-filter >li>a');
		var $portfolio = $('.all-work-items');
		$portfolio.isotope({
			itemSelector : '.work-item',
			layoutMode : 'fitRows'
		});
		
		$portfolio_selectors.on('click', function(){
			$portfolio_selectors.removeClass('active');
			$(this).addClass('active');
			var selector = $(this).attr('data-filter');
			$portfolio.isotope({ filter: selector });
			return false;
		});
	});

});