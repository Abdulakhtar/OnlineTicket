

(function ($) {
    var _studentService = abp.services.app.student,
        l = abp.localization.getSource('OnlineTicket'),
        _$modal = $('#StudentCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#StudentsTable');
    _$result = $('#StudentsResult');

    var _$studentsesult = _$result.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#StudentsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$result);
            _studentService.getAll().done(function (result) {
                callback({
                    //recordsTotal: result.totalCount,
                    //recordsFiltered: result.totalCount,
                    data: result
                });
            }).always(function () {
                abp.ui.clearBusy(_$result);
            });
        },
        columns: [
            { "data": "fullName" },
            { "data": "obtainedMarks" },
            {
                "data": function (obj,index) {
                    return obj.obtainedMarks > 33 ? "Pass" : "Fail";
                }
            },
        ],
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$studentsesult.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [

            {
                targets: 0,
                data: 'fullName',
                sortable: false
            },
            {
                targets: 1,
                data: 'obtainedMarks',
                sortable: false
            },
            {
                targets: 2,
                //data: null,
                //sortable: false,
                //autoWidth: false,
                //defaultContent: ''
            }
        ],

    });

    var _$studentsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#StudentsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _studentService.getAll().done(function (result) {
                callback({
                    //recordsTotal: result.totalCount,
                    //recordsFiltered: result.totalCount,
                    data: result
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        columns: [
            { "data": "fullName" },
            { "data": "registrationNumber" },
            { "data": "emailId" },
        ],
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$studentsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [

            {
                targets: 0,
                data: 'fullName',
                sortable: false
            },
            {
                targets: 1,
                data: 'registrationNumner',
                sortable: false
            },
            {
                targets: 2,
                data: 'emailId',
                sortable: false
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-role" data-role-id="${row.id}" data-toggle="modal" data-target="#StudentEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-role" data-role-id="${row.id}" data-role-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var student = _$form.serializeFormToObject();
        //student.grantedPermissions = [];
        //var _$permissionCheckboxes = _$form[0].querySelectorAll("input[name='permission']:checked");
        //if (_$permissionCheckboxes) {
        //    for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
        //        var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
        //        student.grantedPermissions.push(_$permissionCheckbox.val());
        //    }
        //}

        abp.ui.setBusy(_$modal);
        _studentService
            .create(student)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$studentsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-role', function () {
        var studentId = $(this).attr("data-role-id");
        var studentName = $(this).attr('data-role-name');

        deleteStudent(studentId, studentName);
    });

    $(document).on('click', '.edit-role', function (e) {
        var studentId = $(this).attr("data-role-id");
        debugger;
        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Student/EditModal?studentId=' + studentId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#StudentEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('student.edited', (data) => {
        _$studentsTable.ajax.reload();
    });

    function deleteStudent(studentId, studentName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                studentName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _studentService.delete({
                        id: studentId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$studentsTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$studentsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$studentsTable.ajax.reload();
            return false;
        }
    });

    $(document).ready(function () {
        $("#btnData").click(function () {
            $("#StudentsTable").toggle(1000);
        });
    });

    $(document).ready(function () {
        $("#btnResult").click(function () {
            $("#StudentsResult").toggle(1000);
        });
    });

})(jQuery);