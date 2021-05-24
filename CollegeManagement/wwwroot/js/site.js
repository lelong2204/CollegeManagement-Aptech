$(document).ready(function () {
    var defaultImgSrc = $('.upload-img').attr('src');
    if (defaultImgSrc === null || defaultImgSrc === undefined || defaultImgSrc === '') {
        $('.upload-img').attr('src', DEFAULT_IMG)
    }

    var img_index = $('.img-index , .img-detail , .img-fluid');

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
    setTimeout(() =>
        iziToast.success({
            timeout: 3000,
            title: 'Success',
            message: msg,
            position: 'topRight'
        }), 300)
}

function notificationError(msg) {
    setTimeout(() =>
        iziToast.error({
            timeout: 3000,
            title: 'Error',
            message: msg,
            position: 'topRight'
        }), 300)
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

function ExportRegisterForm() {
    var doc = new jsPDF();
    doc.setFontSize(35);
    doc.text("My college", 10, 20);
    doc.line(10, 25, 70, 25);

    doc.setFontSize(24);
    doc.text("Register course",
        doc.internal.pageSize.width / 2, 40, 'center');

    doc.setFontSize(15);
    doc.text("Student Name:", 10, 60);
    doc.text("____________________________", 50, 60);
    doc.text("Gender:", 135, 60);
    doc.text("Male / Female", 155, 60);

    doc.text("Responsible Person Name:", 10, 75);
    doc.text("_____________________________________", 80, 75);

    doc.text("Responsible Person Phone:", 10, 90);
    doc.text("_____________________________________", 80, 90);

    doc.text("Email:", 10, 105);
    doc.text("_____________________________", 30, 105);
    doc.text("Phone:", 120, 105);
    doc.text("________________", 140, 105);

    doc.text("Residential Address:", 10, 120);
    doc.text("____________________________________________", 60, 120);

    doc.text("Permanent Address:", 10, 135);
    doc.text("____________________________________________", 60, 135);

    doc.text("Date of birth:", 10, 150);
    doc.text("____(Month)/____(Date)/________(Year)", 45, 150);

    doc.text("Course Code:", 10, 165);
    doc.text("_____________________________________(Example: \"IT1\")", 45, 165);

    doc.text("Test Score:", 10, 180);
    doc.text("_____________________", 45, 180);

    doc.text("Signature", 150, 215);

    doc.text("Month_____, Date____, Year  20____", 100, 255);

    doc.save('register_form.pdf');
}