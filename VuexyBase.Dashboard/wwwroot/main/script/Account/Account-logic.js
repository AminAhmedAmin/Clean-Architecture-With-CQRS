const input = document.getElementById('upload');
const preview = document.getElementById('uploadedAvatar');

input.addEventListener('change', function () {
    const file = this.files[0];
    if (file) {
        const reader = new FileReader();

        reader.addEventListener("load", function () {
            preview.setAttribute("src", reader.result);
        });

        reader.readAsDataURL(file);
    }
});