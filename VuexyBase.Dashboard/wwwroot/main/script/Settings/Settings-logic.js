

    //tinymce.init({
    //    selector: '.mytexteditor',
    //    plugins: 'link textcolor lists advlist',
    //    toolbar: 'undo redo | formatselect fontsizeselect fontselect | bold italic underline strikethrough superscript | forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link | removeformat',
    //    menubar: false,
    //    branding: false,
    //    font_family_formats: 'Arial=arial,helvetica,sans-serif; Courier New=courier new,courier; Georgia=georgia,palatino; Tahoma=tahoma,arial; Times New Roman=times new roman,times; Verdana=verdana,geneva;'
//});

document.addEventListener('DOMContentLoaded', function () {
    tinymce.init({
        selector: '.mytexteditor',
        height: 300,
        menubar: true,
        plugins: [
            'advlist', 'autolink', 'lists', 'link', 'image', 'charmap', 'preview',
            'anchor', 'searchreplace', 'visualblocks', 'code', 'fullscreen',
            'insertdatetime', 'media', 'table', 'help', 'wordcount'
        ],
        toolbar: 'undo redo | formatselect | ' +
            'bold italic backcolor | alignleft aligncenter ' +
            'alignright alignjustify | bullist numlist outdent indent | ' +
            'removeformat | image link | help',
        content_style: 'body { font-family:Helvetica,Arial,sans-serif; font-size:16px }',
        directionality: 'auto', // Auto detect RTL/LTR
        branding: false,
        resize: true,
        skin: 'oxide',
        setup: function (editor) {
            editor.on('change', function () {
                editor.save();
            });
        }
    });
});

