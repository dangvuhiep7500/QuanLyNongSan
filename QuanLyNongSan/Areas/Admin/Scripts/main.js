// _____________________mobile-nav-toggle_______________

$(document).ready(function() {
    $(".mobile-menu-items-1").click(function() {

        $(".mobile-sub-nav-1").slideToggle(300);
    });
});
$(document).ready(function() {
    $(".mobile-menu-items-2").click(function() {

        $(".mobile-sub-nav-2").slideToggle(300);
    });
});

$(document).ready(function() {
    $(".mobile-menu-items-3").click(function() {

        $(".mobile-sub-nav-3").slideToggle(300);
    });
});






// _______________mess-Btn.onclick____________

$(document).ready(function() {
    $(".mess-btn").click(function() {

        $(".close-btn").css("display", "block");
        $("#noti").css("opacity", "1");
        $("#noti").css("transform", "scale(1)");
        $(".mess-btn").css("display", "none");

    });
});


// ______________close-Btn.onclick_____________


$(document).ready(function() {
    $(".close-btn").click(function() {

        $(".close-btn").css("display", "none");
        $("#noti").css("opacity", "0");
        $("#noti").css("transform", "scale(0)");
        $(".mess-btn").css("display", "block");

    });
});



// ______________mobileMess-Close________________

$(document).ready(function() {
    $("#mobileMessClose").click(function() {

        $(".close-btn").css("display", "none");
        $("#noti").css("opacity", "0");
        $("#noti").css("transform", "scale(0)");
        $(".mess-btn").css("display", "block");

    });
});


//    ______________Scroll_____________

var cuonLen = window.pageYOffset;
window.onscroll = function() {
    var cuonXuong = window.pageYOffset;
    if (cuonXuong < 46) {

        $(".header-nav").css("position", "relative");
        $(".header-nav").css("background-color", "rgba(255,255,255,1)");
        $(".header-nav").css("padding", "0 16px");
        $(".header-nav").css("transition", "none");

        $(".nav-menu").css("position", "relative");
        $(".nav-menu").css("top", "0");
        $(".nav-menu").css("transition", "none");



    } else if (cuonXuong > 130) {
        if (cuonLen > cuonXuong) {

            $(".header-nav").css("position", "fixed");
            $(".header-nav").css("top", "0");
            $(".header-nav").css("left", "0");
            $(".header-nav").css("right", "0");
            $(".header-nav").css("padding", "0 28px");
            $(".header-nav").css("background-color", "#f8fafb");
            $(".header-nav").css("opacity", "1");
            $(".header-nav").css("transition", "all 0.5s linear");

            $(".nav-menu").css("position", "fixed");
            $(".nav-menu").css("top", "79px");
            $(".nav-menu").css("left", "0");
            $(".nav-menu").css("right", "0");
            $(".nav-menu").css("opacity", "1");
            $(".nav-menu").css("transition", "all 0.5s linear");


        } else {

            $(".header-nav").css("top", "-140px");
            $(".header-nav").css("opacity", "0");


            $(".nav-menu").css("top", "-140px");
            $(".nav-menu").css("opacity", "0");

        }
        cuonLen = cuonXuong;
    }
};


// _______________Tăng giảm số lượng đơn hàng_______________________


var tongtien;
const payMoney = $('.pay-money');
for (let i = 0; i < payMoney.length; i++) {
    payMoney[i].innerHTML = `190.000đ`;
}

// _________nhập số lượng từ input____________

$(document).ready(function() {

    $("#number").keyup(function() {

        var value = $(this).val();
        value = isNaN(value) ? 0 : value;
        tongtien = 190000 * value;
        tongtien = tongtien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")

        for (let i = 0; i < payMoney.length; i++) {
            payMoney[i].innerHTML = `${tongtien}đ`;
        }
        $('#modal-const').html(`x ${value}kg`);

        $('#moneyPaySuscess').html(`Số tiền đã đặt là <span class="fw-bold text-danger">${tongtien}đ.</span>`);

    });
});

// _____________( + )__________________

var value = parseInt($("#number").val());
$('#moneyPaySuscess').html(`Số tiền đã đặt là <span class="fw-bold text-danger">190.000đ.</span>`);


function TangValue() {


    value = isNaN(value) ? 0 : value;
    value++;
    $('#number').val(value)
    tongtien = 190000 * value;
    tongtien = tongtien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")

    for (let i = 0; i < payMoney.length; i++) {
        payMoney[i].innerHTML = `${tongtien}đ`;
    }

    $('#modal-const').html(`x ${value}kg`);
    $('#moneyPaySuscess').html(`Số tiền đã đặt là <span class="fw-bold text-danger">${tongtien}đ.</span>`);

}
// ____________( - ) _________________

function GiamValue() {


    value = isNaN(value) ? 1 : value;
    if (value > 1) {
        value--;

        $('#number').val(value)

        tongtien = 190000 * value;
        tongtien = tongtien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
        for (let i = 0; i < payMoney.length; i++) {
            payMoney[i].innerHTML = `${tongtien}đ`;
        }

        $('#modal-const').html(`x ${value}kg`);
        $('#moneyPaySuscess').html(`Số tiền đã đặt là <span class="fw-bold text-danger">${tongtien}đ.</span>`);
    }
}


// _______________nhập tên khách_____________________


$(document).ready(function() {

    $("#name-customer").keyup(function() {

        var value = $(this).val();


        $('#nameSuscess').html(`  ${value}  `);

    });
});
// _______________Xóa-đơn-hàng_______________________

$(document).ready(function() {
    $(".close-product").click(function() {
        $(".product-item-table").remove('');
        $(".product-item").removeClass('show');
        $(".pay-modal-btn").removeClass('show');
        $(".modal-inforProduct").html(`Giỏ hàng trống, bạn cần thêm sản phẩm`)
        $(".basket-count").html(`0`)
        $('#moneyPaySuscess').html(``);


        for (let i = 0; i < payMoney.length; i++) {
            payMoney[i].innerHTML = `0đ`;
        }
    });
});


// _______________Thêm đơn hàng__________________

$(document).ready(function() {
    $(".detail-btn-2").click(function() {
        $(".product-item").addClass('show');
        $(".pay-modal-btn").addClass('show');
        $(".modal-inforProduct").html(`Sản phẩm đã được thêm vào giỏ`)

        $(".basket-count").html(`1`)


    });
});