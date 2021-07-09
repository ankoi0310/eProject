(function ($) {
  "user strict";
  // Preloader Js
  $(window).on('load', function () {
    $('#overlayer').fadeOut(1000);
    var img = $('.bg_img');
    img.css('background-image', function () {
      var bg = ('url(' + $(this).data('background') + ')');
      return bg;
    });
    galleryMasonary();
    galleryMasonaryTwo();
  });
  // play
  function galleryMasonary() {
    // filter functions
    var $grid = $(".auction-wrapper-5");
    var filterFns = {};
    $grid.isotope({
      itemSelector: '.auction-item-5',
      masonry: {
        columnWidth: 0,
      }
    });
    // bind filter button click
    $('ul.filter').on('click', 'li', function () {
      var filterValue = $(this).attr('data-check');
      // use filterFn if matches value
      filterValue = filterFns[filterValue] || filterValue;
      $grid.isotope({
        filter: filterValue
      });
    });
    // change is-checked class on buttons
    $('ul.filter').each(function (i, buttonGroup) {
      var $buttonGroup = $(buttonGroup);
      $buttonGroup.on('click', 'li', function () {
        $buttonGroup.find('.active').removeClass('active');
        $(this).addClass('active');
      });
    });
  }
  // Gallery Masonary
  function galleryMasonaryTwo() {
    // filter functions
    var $gridTwo = $(".auction-wrapper-7");
    var filter = {};
    $gridTwo.isotope({
      itemSelector: '.auction-item-7',
      masonry: {
        columnWidth: 0,
      }
    });
    // bind filter button click
    $('ul.filter').on('click', 'li', function () {
      var filterValueTwo = $(this).attr('data-check');
      // use filterFn if matches value
      filterValueTwo = filter[filterValueTwo] || filterValueTwo;
      $gridTwo.isotope({
        filter: filterValueTwo
      });
    });
    // change is-checked class on buttons
    $('ul.filter').each(function (i, buttonGroup) {
      var $buttonGroupTwo = $(buttonGroup);
      $buttonGroupTwo.on('click', 'li', function () {
        $buttonGroupTwo.find('.active').removeClass('active');
        $(this).addClass('active');
      });
    });
  }
  $(document).ready(function () {
    //Bidding All Events Here
    //New Countdown Starts
    if ($("#bid_counter1").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter1");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter2").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter2");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter3").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter3");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter4").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter4");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter5").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter5");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter6").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter6");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter7").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter7");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter8").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter8");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter9").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter9");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter10").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter10");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter11").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter11");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter12").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter12");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter13").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter13");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter14").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter14");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter15").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter15");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter16").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter16");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter17").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter17");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter18").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter18");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter19").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter19");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter20").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter20");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter21").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter21");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter22").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter22");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter23").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter23");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter24").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter24");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter25").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter25");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter26").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter26");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter27").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter27");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter28").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter28");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter29").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter29");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter30").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter30");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter31").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter31");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter32").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter32");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter33").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter33");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#bid_counter34").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#bid_counter34");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d  : ";
          message += re_hours + "h  : ";
          message += remaining.minutes + "m  : ";
          message += remaining.seconds + "s";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#min_counter_1").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#min_counter_1");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d ";
          message += re_hours + "h ";
          message += remaining.minutes + "m";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#min_counter_1").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#min_counter_2");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d ";
          message += re_hours + "h ";
          message += remaining.minutes + "m";
        }
        counterElement.textContent = message;
      });
    }
    //New Countdown Starts
    if ($("#min_counter_1").length) {
      // If you need specific date then comment out 1 and comment in 2
      // let endDate = "2020/03/20"; //This is 1
      let endDate = (new Date().getFullYear()) + '/' + (new Date().getMonth() + 1) + '/' + (new Date().getDate() + 1); //This is 2
      let counterElement = document.querySelector("#min_counter_3");
      let myCountDown = new ysCountDown(endDate, function (remaining, finished) {
        let message = "";
        if (finished) {
          message = "Expired";
        } else {
          var re_days = remaining.totalDays;
          var re_hours = remaining.hours;
          message += re_days + "d ";
          message += re_hours + "h ";
          message += remaining.minutes + "m";
        }
        counterElement.textContent = message;
      });
    }
    // Nice Select
    $('.select-bar').niceSelect();
    // counter 
    $('.counter').countUp({
      'time': 2500,
      'delay': 10
    });
    // PoPuP 
    $('.popup').magnificPopup({
      disableOn: 700,
      type: 'iframe',
      mainClass: 'mfp-fade',
      removalDelay: 160,
      preloader: false,
      fixedContentPos: false,
      disableOn: 300
    });
    $("body").each(function () {
      $(this).find(".img-pop").magnificPopup({
        type: "image",
        gallery: {
          enabled: true
        }
      });
    })
    //Faq
    $('.faq-wrapper .faq-title').on('click', function (e) {
      var element = $(this).parent('.faq-item');
      if (element.hasClass('open')) {
        element.removeClass('open');
        element.find('.faq-content').removeClass('open');
        element.find('.faq-content').slideUp(300, "swing");
      } else {
        element.addClass('open');
        element.children('.faq-content').slideDown(300, "swing");
        element.siblings('.faq-item').children('.faq-content').slideUp(300, "swing");
        element.siblings('.faq-item').removeClass('open');
        element.siblings('.faq-item').find('.faq-title').removeClass('open');
        element.siblings('.faq-item').find('.faq-content').slideUp(300, "swing");
      }
    });
    //Menu Dropdown Icon Adding
    $("ul>li>.submenu").parent("li").addClass("menu-item-has-children");
    // drop down menu width overflow problem fix
    $('.submenu').parent('li').hover(function () {
      var menu = $(this).find("ul");
      var menupos = $(menu).offset();
      if (menupos.left + menu.width() > $(window).width()) {
        var newpos = -$(menu).width();
        menu.css({
          left: newpos
        });
      }
    });
    $('.menu li a').on('click', function (e) {
      var element = $(this).parent('li');
      if (element.hasClass('open')) {
        element.removeClass('open');
        element.find('li').removeClass('open');
        element.find('ul').slideUp(300, "swing");
      } else {
        element.addClass('open');
        element.children('ul').slideDown(300, "swing");
        element.siblings('li').children('ul').slideUp(300, "swing");
        element.siblings('li').removeClass('open');
        element.siblings('li').find('li').removeClass('open');
        element.siblings('li').find('ul').slideUp(300, "swing");
      }
    })
    // Scroll To Top 
    var scrollTop = $(".scrollToTop");
    $(window).on('scroll', function () {
      if ($(this).scrollTop() < 500) {
        scrollTop.removeClass("active");
      } else {
        scrollTop.addClass("active");
      }
    });
    //Click event to scroll to top
    $('.scrollToTop').on('click', function () {
      $('html, body').animate({
        scrollTop: 0
      }, 500);
      return false;
    });
    //Header Bar
    $('.header-bar').on('click', function () {
      $(this).toggleClass('active');
      $('.overlay').toggleClass('active');
      $('.menu').toggleClass('active');
    })
    $('.overlay').on('click', function () {
      $(this).removeClass('active');
      $('.header-bar').removeClass('active');
      $('.menu').removeClass('active');
      $('.cart-sidebar-area').removeClass('active');
    })
    $('.cart-button, .side-sidebar-close-btn').on('click', function () {
      $(this).toggleClass('active');
      $('.overlay').toggleClass('active');
      $('.cart-sidebar-area').toggleClass('active');
    })
    $('.search-bar').on('click', function () {
      $('.search-form').toggleClass('active');
    })
    // $('.remove-cart').on('click', function (e) {
    //   e.preventDefault();
    //   $(this).parent().parent().hide(300);
    // });
    // Header Sticky Herevar prevScrollpos = window.pageYOffset;
    var scrollPosition = window.scrollY;
    if (scrollPosition >= 1) {
      $(".header-section").addClass('active');
    }
    var header = $(".header-bottom");
    $(window).on('scroll', function () {
      if ($(this).scrollTop() < 1) {
        header.removeClass("active");
      } else {
        header.addClass("active");
      }
    });
    $('.tab ul.tab-menu li').on('click', function (g) {
      var tab = $(this).closest('.tab'),
        index = $(this).closest('li').index();
      tab.find('li').siblings('li').removeClass('active');
      $(this).closest('li').addClass('active');
      tab.find('.tab-area').find('div.tab-item').not('div.tab-item:eq(' + index + ')').hide(10);
      tab.find('.tab-area').find('div.tab-item:eq(' + index + ')').fadeIn(10);
      g.preventDefault();
    });
    //Client Slider
    $('.client-slider').owlCarousel({
      loop: true,
      responsiveClass: true,
      nav: false,
      dots: false,
      loop: true,
      autoplay: true,
      autoplayTimeout: 2000,
      autoplayHoverPause: true,
      items: 1,
      autoHeight: true,
      responsive: {
        768: {
          items: 2,
        },
        992: {
          items: 3,
        },
        1200: {
          items: 3,
        },
      }
    })
    //Auction Slider One
    $('.auction-slider-1').owlCarousel({
      // loop:true,
      nav: false,
      dots: false,
      items: 1,
      autoplay: true,
      autoplayTimeout: 2500,
      autoplayHoverPause: true,
      autoHeight: true,
      margin: 30,
    });
    var owlOne = $('.auction-slider-1');
    owlOne.owlCarousel();
    // Go to the next item
    $('.electro-next').on('click', function () {
      owlOne.trigger('next.owl.carousel');
    })
    // Go to the previous item
    $('.electro-prev').on('click', function () {
      owlOne.trigger('prev.owl.carousel', [300]);
    })
    //Auction Slider
    $('.auction-slider-2').owlCarousel({
      // loop:true,
      nav: false,
      dots: false,
      items: 1,
      autoplay: true,
      autoplayTimeout: 2500,
      autoplayHoverPause: true,
      autoHeight: true,
      margin: 30,
    });
    var owlTwo = $('.auction-slider-2');
    owlTwo.owlCarousel();
    // Go to the next item
    $('.art-next').on('click', function () {
      owlTwo.trigger('next.owl.carousel');
    })
    // Go to the next item
    $('.art-prev').on('click', function () {
      owlTwo.trigger('prev.owl.carousel');
    })
    //Browse Auction Slider
    $('.browse-slider').owlCarousel({
      loop: true,
      nav: false,
      dots: false,
      items: 1,
      autoplay: true,
      autoplayTimeout: 2500,
      autoplayHoverPause: true,
      autoHeight: true,
      responsive: {
        450: {
          items: 2,
        },
        768: {
          items: 3,
        },
        992: {
          items: 5,
        },
        1200: {
          items: 6,
        },
      }
    });
    var owlThree = $('.browse-slider');
    owlThree.owlCarousel();
    // Go to the next item
    $('.bro-next').on('click', function () {
      owlThree.trigger('next.owl.carousel');
    })
    // Go to the previous item
    $('.bro-prev').on('click', function () {
      owlThree.trigger('prev.owl.carousel', [300]);
    })
    //Browse Auction Slider
    $('.browse-slider-2').owlCarousel({
      loop: true,
      nav: false,
      dots: false,
      items: 1,
      autoplay: true,
      autoplayTimeout: 2500,
      autoplayHoverPause: true,
      autoHeight: true,
      responsive: {
        500: {
          items: 2,
        },
        992: {
          items: 3,
        },
        1200: {
          items: 4,
        },
      }
    });
    var owlBrowseTwo = $('.browse-slider-2');
    owlBrowseTwo.owlCarousel();
    // Go to the next item
    $('.bro-next').on('click', function () {
      owlBrowseTwo.trigger('next.owl.carousel');
    })
    // Go to the previous item
    $('.bro-prev').on('click', function () {
      owlBrowseTwo.trigger('prev.owl.carousel', [300]);
    })
    //Browse Auction Slider
    $('.auction-slider-4').owlCarousel({
      // loop: true,
      nav: false,
      dots: true,
      items: 1,
      autoplay: true,
      autoplayTimeout: 2500,
      autoplayHoverPause: true,
      autoHeight: true,
      margin: 30,
      responsive: {
        768: {
          items: 2,
        },
        992: {
          items: 1,
        },
      }
    });
    var owlFour = $('.auction-slider-4');
    owlFour.owlCarousel();
    // Go to the next item
    $('.real-next').on('click', function () {
      owlFour.trigger('next.owl.carousel');
    })
    // Go to the previous item
    $('.real-prev').on('click', function () {
      owlFour.trigger('prev.owl.carousel', [300]);
    })
    //The Password Show
    $('.pass-type').on('click', function () {
      var x = document.getElementById("login-pass");
      if (x.type === "password") {
        x.type = "text";
      } else {
        x.type = "password";
      }
    });
    $(function () {
      $("#slider-range").slider({
        range: true,
        min: 0,
        max: 10000,
        values: [600, 7000],
        slide: function (event, ui) {
          $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
      });
      $("#amount").val("$" + $("#slider-range").slider("values", 0) + " - $" + $("#slider-range").slider("values", 1));
    });
    var sync1 = $("#sync1");
    var sync2 = $("#sync2");
    var thumbnailItemClass = '.owl-item';
    var slides = sync1.owlCarousel({
      startPosition: 12,
      items: 1,
      loop: true,
      margin: 0,
      mouseDrag: true,
      touchDrag: true,
      pullDrag: false,
      scrollPerPage: true,
      autoplayHoverPause: false,
      nav: false,
      dots: false,
    }).on('changed.owl.carousel', syncPosition);

    function syncPosition(el) {
      $owl_slider = $(this).data('owl.carousel');
      var loop = $owl_slider.options.loop;

      if (loop) {
        var count = el.item.count - 1;
        var current = Math.round(el.item.index - (el.item.count / 2) - .5);
        if (current < 0) {
          current = count;
        }
        if (current > count) {
          current = 0;
        }
      } else {
        var current = el.item.index;
      }

      var owl_thumbnail = sync2.data('owl.carousel');
      var itemClass = "." + owl_thumbnail.options.itemClass;

      var thumbnailCurrentItem = sync2
        .find(itemClass)
        .removeClass("synced")
        .eq(current);
      thumbnailCurrentItem.addClass('synced');

      if (!thumbnailCurrentItem.hasClass('active')) {
        var duration = 500;
        sync2.trigger('to.owl.carousel', [current, duration, true]);
      }
    }
    var thumbs = sync2.owlCarousel({
      startPosition: 12,
      items: 2,
      loop: false,
      margin: 0,
      autoplay: false,
      nav: false,
      dots: false,
      responsive: {
        500: {
          items: 3,
        },
        768: {
          items: 4,
        },
        992: {
          items: 5,
        },
        1200: {
          items: 6,
        },
      },
      onInitialized: function (e) {
        var thumbnailCurrentItem = $(e.target).find(thumbnailItemClass).eq(this._current);
        thumbnailCurrentItem.addClass('synced');
      },
    })
      .on('click', thumbnailItemClass, function (e) {
        e.preventDefault();
        var duration = 500;
        var itemIndex = $(e.target).parents(thumbnailItemClass).index();
        sync1.trigger('to.owl.carousel', [itemIndex, duration, true]);
      }).on("changed.owl.carousel", function (el) {
        var number = el.item.index;
        $owl_slider = sync1.data('owl.carousel');
        $owl_slider.to(number, 500, true);
      });
    sync1.owlCarousel();
    // Go to the next item
    $('.det-next').on('click', function () {
      sync1.trigger('next.owl.carousel');
      sync2.trigger('next.owl.carousel');
    })
    // Go to the previous item
    $('.det-prev').on('click', function () {
      sync1.trigger('prev.owl.carousel', [300]);
      sync2.trigger('prev.owl.carousel', [300]);
    })
  });
})(jQuery);

/*chia trang theo selector*/


function PageDivide(flag) {
  var numberItems = document.getElementById("productArt").getElementsByClassName("col-sm-10 col-md-6 col-lg-4").length;
  var items = document.getElementById("productArt").getElementsByClassName("col-sm-10 col-md-6 col-lg-4");
  var i = 0;
  var e = document.getElementById("devidePage");
  var strOption = e.options[e.selectedIndex].text;
  var numberOption = parseInt(strOption);
  for (i; i < numberItems; i++) {
    var x = items[i].getElementsByTagName('div')[0];
    if (i <= numberOption - 1 && x.style.display === "none") {
      x.style.display = "block";
    }
    if (i > numberOption - 1) {
      x.style.display = "none";
    }
  }
}
/*chia nho doan van*/
function ParagraphDivide() {
  var art = document.getElementById("ourgallery").getElementsByClassName("columnArt");
  var numberArt = art.length;
  for (var y = 0; y < numberArt; y++) {
    var paragraph = art[y].getElementsByTagName("p")[0];
    var paragraph1 = paragraph.innerHTML;
    var x = "........";
    if (paragraph1.length <= 50) {
      paragraph1 = paragraph1 + x;
    }
    var i = 100;
    while (paragraph1[i] != ' ') {
      i++;
    }
    paragraph.innerHTML = paragraph1.substring(0, i) + x;
  }
}


/* chia trang */
function totalPage(numberItemsInpage, Item) {
  // var arts = document.getElementById("ourgallery").getElementsByClassName("columnArt");
  var ItemLeght = Item.length;
  var totalPages = Math.floor(ItemLeght / numberItemsInpage + 1);
  if (ItemLeght % numberItemsInpage > 0) {
    var totalPages = Math.floor(ItemLeght / numberItemsInpage + 1);
  }
  else {
    var totalPages = Math.floor(ItemLeght / numberItemsInpage);
  }
  return totalPages;
}

function pageOne(numberItemsInpage, Item) {
  // var arts = document.getElementById("ourgallery").getElementsByClassName("columnArt");
  var ItemLeght = Item.length;
  for (var i = 0; i < ItemLeght; i++) {
    if (i >= 0 && i <= numberItemsInpage - 1) {
      Item[i].style.display = "block";
    }
    else {
      Item[i].style.display = "none";
    }
  }
}

/*divide Page for Gallery*/

function Page(numberArtInAPage) {
  var i = 0;
  var pageClick = document.getElementById("pagegallery").getElementsByClassName("active")[0].text;
  var arts = document.getElementById("ourgallery").getElementsByClassName("columnArt");
  var ItemLeght = arts.length;
  for (i; i < ItemLeght; i++) {
    if (i >= ((pageClick - 1) * numberArtInAPage) && i < numberArtInAPage * pageClick) {
      arts[i].style.display = "block";
    }
    else { arts[i].style.display = "none"; }
  }
}

function Active(a) {
  var x = document.getElementById("pagegallery").getElementsByTagName("a");
  var b = a.querySelector("a");
  var length = x.length;
  for (var i = 0; i < length; i++) {
    if (x[i] == b) {
      x[i].className = "active";
    }
    else {
      x[i].classList.remove("active");
    }
  }
}

function element(totalPages, page, ulTag, numberArtInAPage) {
  let litag = '';
  let beforePage = page - 1;
  let afterPage = page + 1;
  let activeLi;
  if (totalPages < 5) {
    for (var i = 0; i < totalPages; i++) {
      litag += `<li onclick="Active(this);Page(${numberArtInAPage})"><a href="#0">${i + 1}</a></li>`;
    }
  }
  else {
    if (page > 1) {
      litag += `<li  onclick="element(${totalPages},${page - 1});Page(${numberArtInAPage});"><a href="#0"><i class="flaticon-left-arrow"></i></a></li>`
    }
    if (page > 2) {
      litag += `<li onclick="element(${totalPages},1);Page(${numberArtInAPage});"><a href="#0">1</a></li>`
      if (page > 3) {
        litag += `<li><span>...</span></li>`
      }
    }
    for (let pageLenght = beforePage; pageLenght <= afterPage; pageLenght++) {
      if (pageLenght > totalPages) {
        continue;
      }
      if (pageLenght == 0) {
        pageLenght = pageLenght + 1;
      }
      if (page == pageLenght) {
        activeLi = "active";
      }
      else {
        activeLi = "";
      }
      litag += `<li  onclick="element(${totalPages},${pageLenght});Page(${numberArtInAPage});"><a href="#0" class=${activeLi}>${pageLenght}</a></li>`;
    }
    if (page < totalPages - 1) {
      if (page < totalPages - 2) {
        litag += `<li><span>...</span></li>`
      }
      litag += `<li onclick="element(${totalPages},${totalPages});Page(${numberArtInAPage})"><a href="#0">${totalPages}</a></li>`
    }
    if (page < totalPages) {
      litag += `<li onclick="element(${totalPages},${page + 1});Page(${numberArtInAPage})"><a href="#0" ><i class="flaticon-right-arrow"></i></a></li>`
    }
  }

  ulTag.innerHTML = litag;
}

/* cart */
 function AddToCardCliked(event) {
   var button = event.target;
   var price = button.innerHTML.replace("Buy Now: $", "");
   var srcImg = document.getElementById("sync1").getElementsByTagName("img")[0].src;
   var title = document.getElementById("title").innerText;
   var amount = document.getElementById("Amount");
   var product = { title, price, srcImg };
     var numberAmount = parseInt(amount.innerText);
     
     localStorage.setItem("amount", numberAmount += 1);
    amount.innerHTML = localStorage.getItem("amount");
     AddItemToCard(title, price, srcImg);
     var card = document.getElementById("productItem").innerHTML;
     localStorage.setItem("cards", card);
 }



function AddItemToCard(title, price, srcImg) {
  var card = document.getElementById("productItem");
  var sigleProduct = `<div class="single-product-item">
  <div class="thumb">
      <a href="#0"><img src="${srcImg}" alt="shop"></a>
  </div>
  <div class="content">
      <h4 class="title"><a href="#0">${title}</a></h4>
      <div class="price"><span class="pprice">$${price}</span> <del class="dprice">$120.00</del>
      </div>
      <a href="#" class="remove-cart">Remove</a>
  </div>
</div>`
  card.innerHTML += sigleProduct;
  removeCard();
}

function removeCard() {
  var btnRemoveCard = document.getElementById("productItem").getElementsByClassName("remove-cart");
  for (var i = 0; i < btnRemoveCard.length; i++) {
    var button = btnRemoveCard[i];
    button.addEventListener("click", function (event) {
      var buttonClicked = event.target;
      buttonClicked.parentElement.parentElement.remove();
      var amount = document.getElementById("Amount");
      var numberAmount= parseInt(amount.innerText);
        localStorage.setItem("amount", numberAmount -= 1)
        amount.innerHTML = localStorage.getItem("amount");
        var card = document.getElementById("productItem").innerHTML;
        localStorage.setItem("cards", card);
    })  
  }
}
function getRate() {
    var star = document.getElementsByName("rate");
    var prev = null;
    for (var i = 0; i < star.length; i++) {
        star[i].addEventListener('change', function () {
            console.log(this.value)
        });
    }
}
/*divide end Page for Gallery*/
