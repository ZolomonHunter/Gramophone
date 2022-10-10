var btnContainer = document.getElementById("navbar");


var btns = btnContainer.getElementsByClassName("menu-item");


for (var i = 0; i < btns.length; i++) {
  btns[i].addEventListener("click", function() {
    var current = document.getElementsByClassName("active");
    current[0].className = current[0].className.replace(" active", "");
    this.className += " active";
  });
}


$(function(){

  $('.genre-slider').slick({
    infinite: false,
    slidesToShow: 3,
    slidesToScroll: 1,
    arrows:false,
    dots:true,
    autoplay: true,
  autoplaySpeed: 2200,
  
  })
})


