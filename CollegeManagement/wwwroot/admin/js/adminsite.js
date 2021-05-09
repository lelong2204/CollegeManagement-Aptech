$(document).ready(function () {
    var defaultImgSrc = $('.upload-img').attr('src');
    if (defaultImgSrc === null || defaultImgSrc === undefined || defaultImgSrc === '') {
        $('.upload-img').attr('src', DEFAULT_IMG)
    }

    var img_index = $('.img-index');

    if (img_index && img_index.length) {
        $.each(img_index, function (i, data) {
            console.log
            if (data.src == undefined || !data.src || data.src === '') {
                data.src = DEFAULT_IMG
            }
        })
    }
    
    $(document).on('error', '.upload-img', function () {
        $(this).attr('src', DEFAULT_IMG)
    })

    $('#img-select-btn').on('click', function () {
        $('#image-select').trigger('click');
    })

    $('#image-select').on('change', function () {
        if ($(this).get(0) && $(this).get(0).files && $(this).get(0).files.length > 0) {

            if (!$(this).get(0).files[0].type.includes('image')) {
                $(this).val(null);

            } else {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.upload-img').attr('src', e.target.result);
                }

                reader.readAsDataURL($(this).get(0).files[0]);
            }
        }
    })

    var url = window.location.pathname.toUpperCase(),
        urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");

    $('.sidebar-item a').each(function () {
        if (urlRegExp.test(this.href.replace(/\/$/, '').toUpperCase())) {
            $(this).parent().addClass('active');
            document.querySelector('.sidebar-item.active').scrollIntoView(false)
        }
    });

    $('.select2').select2({ allowClear: true, placeholder: "Select option" })
    $('.select2-multiple').select2({ allowClear: true, placeholder: "Select option" })
})

function notificationSuccess(msg) {
    iziToast.success({
        timeout: 3000,
        title: 'Success',
        message: msg,
        position: 'topRight'
    })
}

function notificationError(msg) {
    iziToast.error({
        timeout: 3000,
        title: 'Error',
        message: msg,
        position: 'topRight'
    })
}

const DEFAULT_IMG = '/admin/assets/images/default-image.jpg';