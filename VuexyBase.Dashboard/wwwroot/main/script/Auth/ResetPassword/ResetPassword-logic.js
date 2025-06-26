//// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict';

    const forms = document.querySelectorAll('.needs-validation');

    Array.prototype.slice.call(forms).forEach(function (form) {
        const password = form.querySelector('#password');
        const confirmPassword = form.querySelector('#confirm-password');

        // Validate on input
        password.addEventListener('input', validate);
        confirmPassword.addEventListener('input', validate);

        form.addEventListener('submit', function (event) {
            validate(); // Ensure validation before submit

            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }

            form.classList.add('was-validated');
        });

        function validate() {
            // Clear custom messages first
            password.setCustomValidity('');
            confirmPassword.setCustomValidity('');

            // Password length check
            if (password.value.length < 6) {
                password.setCustomValidity('Password must be at least 6 characters long.');
            }

            // Confirm match check
            if (confirmPassword.value !== password.value) {
                confirmPassword.setCustomValidity('Passwords do not match.');
            }

            // Refresh validation styles
            form.classList.add('was-validated');
        }
    });
})();
