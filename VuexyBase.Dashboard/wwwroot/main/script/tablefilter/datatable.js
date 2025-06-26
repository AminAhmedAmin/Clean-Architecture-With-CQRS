//// Bind custom search, length, buttons, and add
//const $table = $('.datatables-table'); // or whatever class/id your table has

//dt = $table.DataTable({
//    dom: 't', // manual control
//    // ...
//    buttons: [
//        {
//            extend: 'collection',
//            className: 'btn btn-label-secondary dropdown-toggle mx-3',
//            text: '<i class="ti ti-screen-share me-1 ti-xs"></i>Export',
//            buttons: ['print', 'csv', 'excel', 'pdf', 'copy']
//        }
//    ],
//    // ...
//});

//dt.buttons().container().appendTo('#datatable-buttons-placeholder');

//// Search filter binding
//$('#datatable-search').on('keyup', function () {
//    dt.search(this.value).draw();
//});

//// Length dropdown binding
//$('select[name="datatable_length"]').on('change', function () {
//    dt.page.len(this.value).draw();
//});
