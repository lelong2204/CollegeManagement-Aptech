$(document).ready(function () {
    var defaultImgSrc = $('.upload-img').attr('src');
    if (defaultImgSrc === null || defaultImgSrc === undefined || defaultImgSrc === '') {
        $('.upload-img').attr('src', DEFAULT_IMG)
    }

    var img_index = $('.img-index , .img-detail');

    if (img_index && img_index.length) {
        $.each(img_index, function (i, data) {
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

    var url = window.location.pathname.toUpperCase();

    if (url === "/ADMIN") {
        $("#home_page").addClass('active');
    } else {
        $('.sidebar-item a').each(function () {

            if (url.includes($(this).attr("href").toUpperCase())) {
                $(this).parent().addClass('active');
                document.querySelector('.sidebar-item.active').scrollIntoView(false)
            }
        });
    }

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

function addIndicator() {
    $('body').append(
        $('<div>').html(`
			<div class="swal2-container swal2-center swal2-backdrop-show d-flex justify-content-center" id="indicator_loading">
				<div class="spinner-border" style="color: #007bff !important;width: 3rem; height: 3rem;" role="status">
					<span class="sr-only">Loading...</span>
				 </div>
			</div>
		`)
    )
}

function removeIndicator() {
    $('#indicator_loading').remove();
}

const DEFAULT_IMG = '/admin/assets/images/default-image.jpg';