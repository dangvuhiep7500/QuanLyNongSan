
   var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Home/Index";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Order/Payment";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Order/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Order/Index";
                    }
                }
            })
        });
     

        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/GioHang/DeleteAll',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang/Index";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Order/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Order/Index";
                    }
                }
            })
        });
    }
}
cart.init();

jQuery(document).ready(function ($) {
    $(".scroll").click(function (event) {
        event.preventDefault();
        $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
    });
});

jQuery(document).ready(function ($) {
    $(".switcher-btn").click(function () {
        $(".switcher-wrapper").toggleClass("switcher-toggled")
    });
    $("#page").click(function () {
        $(".switcher-wrapper").removeClass("switcher-toggled")
    });
    $('option').mousedown(function (e) {
        e.preventDefault();
        $(this).toggleClass('selected');

        $(this).prop('selected', !$(this).prop('selected'));
        return false;
    });
    $(".btn-themvaogio").click(function () {
        var product_id = $(this).val();
        $.ajax({
            url: '/GioHang/ThemVaoGio?SanPhamID=' + product_id,
            data: { SanPhamID: product_id },
            success: function (data) {
                $("body").load(location.href)
                /*alertify.set('notifier', 'position', 'top-right');
                alertify.success('Current position ');*/
            },
            error: function (data) {
                alert('Sản phẫm lỗi');
            }
        });

    });
    $('.btn-detailthemvaogio').click(function () {
        var product_id = $(this).val();
        $.ajax({
            url: '/GioHang/ThemVaoGio?SanPhamID=' + product_id,
            data: { SanPhamID: product_id },
            success: function (data) {
                $(".switcher-wrapper").toggleClass("switcher-toggled")
                $("body").load(location.href)
            },
            error: function (data) {

                alert('Sản phẫm lỗi');

            }
        });

    });
    $('.btn-xoakhoigio').click(function () {
        var product_id_delete = $(this).val();
        $.ajax({
            url: '/GioHang/XoaKhoiGio?SanPhamID=' + product_id_delete,
            data: { SanPhamID: product_id_delete },
            success: function (data) {
                $(".switcher-wrapper").toggleClass("switcher-toggled")
                $('body').load(location.href)
            },
            error: function (data) {

                alert('Sản phẫm lỗi');

            }
        });

    });
    $('.giohangprice').click(function () {
        var product_id = $(this).closest('.formsoluong').find('.idsp').val();
        var soluong = $(this).closest('.formsoluong').find('.soluongsp').val();
        $.ajax({
            url: '/GioHang/SuaSoLuong?SanPhamID=' + product_id + '&soluongmoi=' + soluong,
            data: { SanPhamID: product_id, soluongmoi: soluong },
            success: function (data) {
                $('body').load(location.href);
            },
            error: function (data) {
                alert('Sản phẫm lỗi');
            }
        });
    });

});

