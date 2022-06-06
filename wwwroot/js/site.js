// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var n = 0;
window.ev = false;
document.getElementById("carousel-inner").onmouseenter = function () {
    window.ev = true;
};
document.getElementById("carousel-inner").onmouseleave = function () {
    window.ev = false;
    setTimeout(autoSlide, 400);
};

function autoSlide() {
    if (window.ev == false) {
        n++;
        if (n === 4)
            n = 1;
        document.getElementById("carousel-" + n).checked = true;
        setTimeout(autoSlide, 4000);
    }
}
autoSlide();