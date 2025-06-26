$(document).ready(function () {
    $('#formAccountSettings').on('submit', function (e) {
        const currentPassword = $('#currentPassword');
        const newPassword = $('#newPassword');
        const confirmPassword = $('#confirmPassword');

        const currentVal = currentPassword.val().trim();
        const newVal = newPassword.val().trim();
        const confirmVal = confirmPassword.val().trim();

        toastr.clear();

        let isValid = true;

        // Helper to toggle input border
        function setValidation(input, valid) {
            if (valid) {
                input.removeClass('is-invalid').addClass('is-valid');
            } else {
                input.removeClass('is-valid').addClass('is-invalid');
                isValid = false;
            }
        }

        // Check all fields are filled
        setValidation(currentPassword, !!currentVal);
        setValidation(newPassword, !!newVal);
        setValidation(confirmPassword, !!confirmVal);

        if (!currentVal || !newVal || !confirmVal) {
            e.preventDefault();
            toastr.error("جميع الحقول مطلوبة");
            return;
        }

        // Password length
        if (newVal.length < 6) {
            e.preventDefault();
            setValidation(newPassword, false);
            toastr.error("كلمة المرور الجديدة يجب أن تكون على الأقل 6 أحرف");
            return;
        } else {
            setValidation(newPassword, true);
        }

        // Match check
        if (newVal !== confirmVal) {
            e.preventDefault();
            setValidation(confirmPassword, false);
            toastr.error("كلمة المرور الجديدة غير متطابقة");
            return;
        } else {
            setValidation(confirmPassword, true);
        }

        // Password strength check
        const hasLowercase = /[a-z]/.test(newVal);
        const hasNumberOrWhitespace = /[\d\s]/.test(newVal);

        if (!hasLowercase || !hasNumberOrWhitespace) {
            e.preventDefault();
            setValidation(newPassword, false);
            toastr.error("كلمة المرور يجب أن تحتوي على حرف صغير ورقم أو مسافة");
            return;
        }

        // If everything passes, form submits
    });

    // Optional: live validation while typing
    $('#confirmPassword').on('input', function () {
        const newPassword = $('#newPassword').val().trim();
        const confirmPassword = $(this).val().trim();
        if (confirmPassword && newPassword !== confirmPassword) {
            $(this).removeClass('is-valid').addClass('is-invalid');
        } else if (confirmPassword && newPassword === confirmPassword) {
            $(this).removeClass('is-invalid').addClass('is-valid');
        } else {
            $(this).removeClass('is-valid is-invalid');
        }
    });
});
