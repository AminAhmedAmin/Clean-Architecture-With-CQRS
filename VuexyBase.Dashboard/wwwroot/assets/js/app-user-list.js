
//'use strict';

//// Datatable (jquery)
//$(function () {
//  let borderColor, bodyBg, headingColor;

//  if (isDarkStyle) {
//    borderColor = config.colors_dark.borderColor;
//    bodyBg = config.colors_dark.bodyBg;
//    headingColor = config.colors_dark.headingColor;
//  } else {
//    borderColor = config.colors.borderColor;
//    bodyBg = config.colors.bodyBg;
//    headingColor = config.colors.headingColor;
//  }

//  // Variable declaration for table
//  var dt_user_table = $('.datatables-users'),
//    select2 = $('.select2'),
//    userView = 'app-user-view-account.html',
//    statusObj = {
//      1: { title: 'Pending', class: 'bg-label-warning' },
//      2: { title: 'Active', class: 'bg-label-success' },
//      3: { title: 'Inactive', class: 'bg-label-secondary' }
//    };

//  if (select2.length) {
//    var $this = select2;
//    $this.wrap('<div class="position-relative"></div>').select2({
//      placeholder: 'Select Country',
//      dropdownParent: $this.parent()
//    });
//  }


//  // Delete Record
//  $('.datatables-users tbody').on('click', '.delete-record', function () {
//    dt_user.row($(this).parents('tr')).remove().draw();
//  });

//  // Filter form control to default size
//  // ? setTimeout used for multilingual table initialization
//  setTimeout(() => {
//    $('.dataTables_filter .form-control').removeClass('form-control-sm');
//    $('.dataTables_length .form-select').removeClass('form-select-sm');
//  }, 300);
//});

//();
