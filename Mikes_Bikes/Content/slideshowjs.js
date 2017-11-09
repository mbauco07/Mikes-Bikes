/*
'use strict';

$(function () {
    //config
    var width = 720;
    var animationSpeed = 1000;
    var pause = 3000;
    var currentSlide = 1;

    var $slider = $('#slider');
    var $slideContainer = $slider.find('.slides');
    var slides = $slideContainer.find('.slide');

    var interval;

    function startSlider() {
        var interval = setInterval(function () {
            $slideContainer.animate({ 'margin-left': '-=' + width }, animationSpeed, function () {
                currentSlide++;
                if (currentSlide === slides.length) {
                    currentSlide = 1;
                    $slideContainer.css('margin-left', 0);
                }
            });
        }, pause);
    }

    function stopSlider() {
        clearInterval(interval);
    }

    $slider.on('mouseenter', stopSlider).on('mouseleave', startSlider);
});
*/

$("#slideshow > div:gt(0)").hide();

setInterval(function () {
    $('#slideshow > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#slideshow');
}, 3000);