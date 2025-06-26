'use strict';

$(function () {
    let borderColor, bodyBg, headingColor;

    if (isDarkStyle) {
        borderColor = config.colors_dark.borderColor;
        bodyBg = config.colors_dark.bodyBg;
        headingColor = config.colors_dark.headingColor;
    } else {
        borderColor = config.colors.borderColor;
        bodyBg = config.colors.bodyBg;
        headingColor = config.colors.headingColor;
    }

    var dt_country_table = $('#CountriesTable');
    if (dt_country_table.length) {
        var countries = dt_country_table.DataTable({
            serverSide: true,
            processing: true,
            orderMulti: true,
            ajax: {
                url: '/Countries/GetCountries',
                type: 'POST',
                data: function (d) {
                    return {
                        draw: d.draw,
                        start: d.start,
                        length: d.length,
                        search: { value: $('#searchString').val(), regex: d.search.regex },
                        order: d.order.length > 0 ? [{ column: d.order[0].column, dir: $('#sortDirection').val() || d.order[0].dir }] : [],
                        columns: d.columns.map(function (column, index) {
                            return {
                                data: column.data,
                                name: column.data, // Use data as name for consistency
                                searchable: column.searchable,
                                orderable: column.orderable,
                                search: { value: column.search.value, regex: column.search.regex }
                            };
                        }),
                        StartDate: $('#creationDate').val(),
                        EndDate: $('#endDate').val()
                    };
                },
                dataFilter: function (data) {
                    var json = JSON.parse(data);
                    return JSON.stringify({
                        draw: json.pagination.draw,
                        recordsTotal: json.pagination.recordsTotal,
                        recordsFiltered: json.pagination.recordsFiltered,
                        data: json.result
                    });
                }
            },
            columns: [
                // Responsive control column (for the "+" icon and row ID)
                {
                    className: 'control',
                    orderable: false,
                    searchable: false,
                    data: null,
                    defaultContent: '',
                },
                // Checkbox column
                {
                    data: null,
                    searchable: false,
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return (
                            '<label class="custom-checkbox">' +
                            '<input type="checkbox" class="dt-checkboxes">' +
                            '<span class="checkbox-style"></span>' +
                            '</label>'
                        );
                    },
                    className: 'dt-center',
                    checkboxes: {
                        selectRow: true
                    }
                },
                // ID column (hidden since we're showing it in the control column)
                {
                    data: 'id',
                    searchable: false,
                    orderable: false,
                    visible: false
                },
                { data: 'nameAr' }, // الاسم بالعربية
                { data: 'nameEn' }, // الاسم بالانجليزية
                { data: 'code' },   // كود الدولة
                {
                    data: 'image',
                    searchable: false,
                    orderable: false,
                    render: function (data, type, row) {
                        return data != null ? `<img src="/${data}" alt="Country Image" width="50" height="50">` : 'No Image';
                    }
                },
                {
                    data: 'isActive',
                    render: function (data, type, row) {
                        return data
                            ? `<span class="badge bg-label-success text-capitalized" id="isActive-${row.id}">Active</span>`
                            : `<span class="badge bg-label-secondary text-capitalized" id="isActive-${row.id}">Inactive</span>`;
                    }
                },
                {
                    data: 'Actions',
                    render: function (data, type, row) {
                        return (
                            '<div class="d-flex align-items-center">' +
                            `<a href="/Countries/Update/${row.id}" class="text-body"><i class="ti ti-edit ti-sm me-2"></i></a>` +
                            `<button onclick="showDeleteModal(${row.id})" style="background: none; border: none; padding: 0; cursor: pointer;" class="text-body"><i class="ti ti-trash ti-sm mx-2"></i></button>` +
                            '<a href="javascript:;" class="text-body dropdown-toggle hide-arrow" data-bs-toggle="dropdown"><i class="ti ti-dots-vertical ti-sm mx-1"></i></a>' +
                            '<div class="dropdown-menu dropdown-menu-end m-0">' +
                            `<button onclick="toggleIsActive(${row.id})" class="dropdown-item">Suspend</button>` +
                            '</div>' +
                            '</div>'
                        );
                    }
                }
            ],
            columnDefs: [
                { targets: 0, width: '5%', searchable: false, orderable: false }, // Responsive control column
                { targets: 1, width: '30px', searchable: false, orderable: false }, // Checkbox column
                { targets: 2, visible: false }, // Hidden ID column
                { targets: [3, 4, 5], searchable: true, orderable: true }, // nameAr, nameEn, code
                { targets: [6, 7, 8], searchable: false, orderable: false } // image, status, actions
            ],
            dom:
                '<"row me-2"' +
                '<"col-md-2"<"me-3"l>>' +
                '<"col-md-10"<"dt-action-buttons text-xl-end text-lg-start text-md-end text-start d-flex align-items-center justify-content-end flex-md-row flex-column mt-3 mb-3"B>>' +
                '>t' +
                '<"row mx-2"' +
                '<"col-sm-12 col-md-6"i>' +
                '<"col-sm-12 col-md-6"p>' +
                '>',
            pageLength: 10,
            lengthMenu: [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]],
            language: {
                info: "",
                paginate: { previous: "السابق", next: "التالي" },
                select: { rows: "" }
            },
            select: {
                style: 'multi',
                selector: 'td:not(.control) input.dt-checkboxes',
                className: ''
            },
            buttons: [
                {
                    extend: 'collection',
                    className: 'btn btn-label-secondary dropdown-toggle mx-3',
                    text: '<i class="ti ti-screen-share me-1 ti-xs"></i>Export',
                    buttons: [
                        {
                            extend: 'print',
                            text: '<i class="ti ti-printer me-2" ></i>Print',
                            className: 'dropdown-item',
                            exportOptions: { columns: [2, 3, 4, 5, 6] }
                        },
                        {
                            extend: 'csv',
                            text: '<i class="ti ti-file-text me-2" ></i>Csv',
                            className: 'dropdown-item',
                            exportOptions: { columns: [2, 3, 4, 5, 6] }
                        },
                        {
                            extend: 'excel',
                            text: '<i class="ti ti-file-spreadsheet me-2"></i>Excel',
                            className: 'dropdown-item',
                            exportOptions: { columns: [2, 3, 4, 5, 6] }
                        },
                        {
                            extend: 'pdf',
                            text: '<i class="ti ti-file-code-2 me-2"></i>Pdf',
                            className: 'dropdown-item',
                            exportOptions: { columns: [2, 3, 4, 5, 6] }
                        },
                        {
                            extend: 'copy',
                            text: '<i class="ti ti-copy me-2" ></i>Copy',
                            className: 'dropdown-item',
                            exportOptions: { columns: [2, 3, 4, 5, 6] }
                        }
                    ]
                },
                {
                    text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Country</span>',
                    className: 'add-new btn btn-primary',
                    attr: { 'data-bs-toggle': 'offcanvas', 'data-bs-target': '#offcanvasAddData' }
                }, {
                    text: '<i class="fa fa-filter"></i><span class="d-none d-sm-inline-block" style="margin-right:5px;">Filter</span>',
                    className: ' btn btn-filter',
                    attr: { 'data-bs-toggle': 'offcanvas', 'data-bs-target': '#offcanvasFilter' }
                },
                {
                    text: '<i class="ti ti-trash me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Delete Selected Rows</span>',
                    className: 'btn btn-danger delete-selected mx-3',
                    attr: { id: 'deleteSelectedBtn' },
                    action: function (e, dt, node, config) {
                        var selectedRows = dt.rows({ selected: true }).data();
                        if (selectedRows.length === 0) {
                            toastr.warning('No rows selected!');
                            return;
                        }

                        var ids = [];
                        selectedRows.each(function (row) {
                            ids.push(row.id);
                        });

                        $('#deleteCount').text(ids.length);
                        $('#deleteMultipleConfirmModal').modal('show');

                        $('#confirmDeleteMultipleBtn').off('click').on('click', function () {
                            $.ajax({
                                url: '/Countries/DeleteMultiple',
                                type: 'POST',
                                data: { ids: ids },
                                success: function (response) {
                                    if (response.success) {
                                        toastr.success('Selected rows deleted successfully!');
                                        dt.ajax.reload(function () {
                                            dt.rows().deselect();
                                            $('#deleteSelectedBtn').addClass('d-none');
                                        }, false);
                                        $('#deleteMultipleConfirmModal').modal('hide');
                                    } else {
                                        toastr.error('Failed to delete rows: ' + (response.message || 'Unknown error'));
                                        $('#deleteMultipleConfirmModal').modal('hide');
                                    }
                                },
                                error: function (xhr, status, error) {
                                    toastr.error('Error deleting rows: ' + error);
                                    $('#deleteMultipleConfirmModal').modal('hide');
                                }
                            });
                        });
                    }
                }
            ],
            initComplete: function () {
                var headerCheckbox = this.api().column(1).header();
                var $headerCheckbox = $(headerCheckbox).find('input[type="checkbox"]');
                if ($headerCheckbox.length) {
                    $headerCheckbox.wrap('<label class="custom-checkbox"></label>')
                        .after('<span class="checkbox-style"></span>')
                        .addClass('dt-checkboxes');
                }
            },
            responsive: {
                details: {
                    display: $.fn.dataTable.Responsive.display.modal({
                        header: function (row) {
                            var data = row.data();
                            return 'Details of ' + (data.nameEn || data.nameAr || 'Country');
                        }
                    }),
                    type: 'column',
                    renderer: function (api, rowIdx, columns) {
                        var data = $.map(columns, function (col, i) {
                            if (col.title === '' || col.title === 'Select') return '';
                            return '<tr data-dt-row="' +
                                col.rowIndex +
                                '" data-dt-column="' +
                                col.columnIndex +
                                '">' +
                                '<td>' +
                                col.title +
                                ':' +
                                '</td> ' +
                                '<td>' +
                                col.data +
                                '</td>' +
                                '</tr>';
                        }).join('');

                        return data ? $('<table class="table"/><tbody />').append(data) : false;
                    }
                }
            }
        });

        $('#deleteSelectedBtn').addClass('hidden-animated hidden-animated-complete');

        // Toggle visibility with animation on select/deselect
        countries.on('select deselect', function () {
            var selectedRows = countries.rows({ selected: true }).count();
            if (selectedRows > 0) {
                $('#deleteSelectedBtn').removeClass('d-none')
                $('#deleteSelectedBtn').removeClass('hidden-animated-complete'); // Make visible immediately
                setTimeout(() => {
                    $('#deleteSelectedBtn').removeClass('hidden-animated'); // Trigger fade-in
                }, 100); // Small delay to ensure display is set before animation
            } else {
                $('#deleteSelectedBtn').addClass('hidden-animated'); // Start fade-out
                setTimeout(() => {
                    $('#deleteSelectedBtn').addClass('hidden-animated-complete');
                    $('#deleteSelectedBtn').addClass('d-none')// Remove from layout
                }, 150); // Match transition duration
            }
        });

        // Ensure hidden on init
        countries.on('init.dt', function () {
            $('#deleteSelectedBtn').addClass('hidden-animated hidden-animated-complete');
            $('#deleteSelectedBtn').addClass('d-none')
        });
    }

    $('#filterForm').on('submit', function (e) {
        e.preventDefault(); // Prevent page reload

        // Get form values
        var creationDate = $('#creationDate').val();
        var endDate = $('#endDate').val();
        var searchString = $('#searchString').val();
        var sortDirection = $('#sortDirection').val();
        var sortProperty = $('#sortProperty').val();

        // Update DataTable
        var dt = $('#CountriesTable').DataTable();

        // Apply search
        if (searchString) {
            dt.search(searchString); // Global search
        } else {
            dt.search(''); // Clear search
        }

        // Custom filtering for dates (server-side or client-side)
        dt.column(7).search(''); // Clear previous custom filters (adjust column index if needed)
        $.fn.dataTable.ext.search.push(
            function (settings, data, dataIndex) {
                var rowData = dt.row(dataIndex).data();
                var creation = rowData.creationDate ? new Date(rowData.creationDate) : null; // Adjust property name
                var end = rowData.endDate ? new Date(rowData.endDate) : null; // Adjust property name

               

                

                return true;
            }
        );

        // Apply sorting
        var columnIndex = dt.columns().indexes().filter(function (i) {
            return dt.column(i).dataSrc() === sortProperty;
        })[0];
        if (columnIndex !== undefined) {
            dt.order([[columnIndex, sortDirection]]);
        }

        // Redraw the table
        dt.draw();

        // Close the offcanvas
        $('#offcanvasFilter').offcanvas('hide');
    });
});

function toggleIsActive(id) {
    $.ajax({
        url: `/Countries/IsActive?countryId=${id}`,
        method: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.success) {
                const element = document.getElementById(`isActive-${id}`);
                element.textContent = 'Active';
                element.classList.remove('bg-label-secondary');
                element.classList.add('bg-label-success');
            } else {
                const element = document.getElementById(`isActive-${id}`);
                element.textContent = 'Inactive';
                element.classList.remove('bg-label-success');
                element.classList.add('bg-label-secondary');
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
            alert("An error occurred while updating the status.");
        }
    });
}

let currentRowId = null;
function showDeleteModal(id) {
    currentRowId = id;
    $('#deleteConfirmModal').modal('show');
}

document.getElementById('confirmDeleteBtn').addEventListener('click', function () {
    if (currentRowId) {
        $.ajax({
            url: `/countries/delete/${currentRowId}`,
            type: 'POST',
            success: function (response) {
                $('#deleteConfirmModal').modal('hide');
                toastr.success('Country deleted successfully!');
                setTimeout(function () {
                    window.location.href = '/Countries';
                }, 1500);
            },
            error: function (xhr, status, error) {
                toastr.failed('Error deleting country: ' + error);
            }
        });
    }

});