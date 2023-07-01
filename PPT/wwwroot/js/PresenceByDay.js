
var doctors = [];
var listSet;

// Function to handle the click event of the "Add Attendance" button
function removeAttendance(ids) {
    //console.log(ids)
    var token = $('input[name="__RequestVerificationToken"]').val();
    $.ajax({
        url: `/PresenceByDay?handler=Delete`,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(ids),
        headers: {
            'XSRF-TOKEN': token
        },
        success: function (response) {
            
        },
        error: function (xhr, status, error) {
            console.error('Failed to remove presence');
        }
    });
}

function toggleAddData() {
        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url: `/PresenceByDay?handler=Doctors`,
            type: 'GET',
            headers: {
                'XSRF-TOKEN': token
            },
            error: function (xhr, status, error) {
                console.error('Failed to remove presence');
            }
        }).done(function (data) {
            var table = $('#doctorsTable');
            if (!$.fn.DataTable.isDataTable('#doctorsTable')) {
                $('#doctorsTable').DataTable({
                    responsive: true,
                    headerCallback: function (thead, data, start, end, display) {
                        $(thead)
                            .find('th')
                            .css('text-align', 'right');
                    },
                    language: {
                        "sEmptyTable": "لا توجد بيانات متاحة في الجدول",
                        "sInfo": "عرض _START_ إلى _END_ من إجمالي _TOTAL_ مُدخل",
                        "sInfoEmpty": "عرض 0 إلى 0 من إجمالي 0 مُدخل",
                        "sInfoFiltered": "(تمت تصفية البيانات من إجمالي _MAX_ مُدخل)",
                        "sInfoPostFix": "",
                        "sInfoThousands": ",",
                        "sLengthMenu": "عرض _MENU_ مُدخل",
                        "sLoadingRecords": "جارٍ التحميل...",
                        "sProcessing": "جارٍ المعالجة...",
                        "sSearch": "بحث:",
                        "sZeroRecords": "لم يتم العثور على أية سجلات مطابقة",
                        "oPaginate": {
                            "sFirst": "الأول",
                            "sLast": "الأخير",
                            "sNext": "التالي",
                            "sPrevious": "السابق"
                        },
                        "oAria": {
                            "sSortAscending": ": تنشيط لترتيب العمود تصاعديًا",
                            "sSortDescending": ": تنشيط لترتيب العمود تنازليًا"
                        },
                        buttons: {
                            selectAll: "حدد الكل",
                            selectNone: "إلغاء التحديد"
                        }
                    },
                    lengthMenu: [[4, 8], [4, 8]],
                    data: data,
                    dom: "<'container d-flex justify-content-between flex-wrap'<'mb-2'Q><'mb-2'l><'mb-2'B><'mb-2'f>>" +
                        "<<tr>>" +
                        "<<i><p>>",
                    buttons: [
                        'selectAll',
                        'selectNone'
                    ],
                    columns: [
                        { title: '#', data: 'id' },
                        { title: 'university id', data: 'universityId' },
                        { title: 'الاسم', data: 'name' },
                        {
                            title: 'المدة (متعاقد)',
                            data: null,
                            render: function (data, type, row) {
                                var disabled = 'disabled';
                                //console.log(data);
                                if (row.isContracted && row.isContracted == true)
                                    disabled = '';
                                var view = row.isContracted && row.isContracted == true ? `<input type="Number" placeholder="عدد" id="doctor_${row.id}" class='form-control cell-datatable' name="duration" ${disabled}  min="1" value="${parseInt(data)}"/>`: 'غير متعاقد';
                                return view;
                            }
                        }
                        //{ data: `<button class="btn btn-danger" onclick="removeAttendance(${id}, '${ encodedDate }')">X</button>` }
                    ],
                    select: true,
                    "initComplete": function (settings, json) {
                        $('#loading-doctors').hide();
                    },
                    "preDrawCallback": function (settings) {
                        $('#loading-doctors').show();
                    },
                    "drawCallback": function (settings) {
                        $('#loading-doctors').hide();
                    }
                });
            }
            else {
                //console.log(data);
                    
                var table = $('#doctorsTable').DataTable();

                // Assign new data to the DataTable

                // Clear the existing data and add the new data
                table.clear().rows.add(data).draw();

            }
            /*$.each(data, function (i, instance) {
                doctors.push(instance);
            });
            //console.log(doctors)

            $.each(doctors, function (i, instance) {

                table.row.add([instance.id, instance.universityId, instance.isContracted, instance.name, `<input class="form-input" type="number" value="">`, `<input class="form-check-input" type="checkbox" value="">`]).draw(false)
            })*/
            //table.draw();

        });
        /*
        <th>id</th>
                    <th>university id</th>
                    <th>is contracted</th>
                    <th>Name</th>
                    <th>Select</th>
        */

}

function edit() {
    const table = $('#attendanceTable').DataTable();
    var rows = table
        .rows();//#doctorAttendance_1
    
    var updates = rows.data().toArray().map((value) => {
        return {
            id: value.attendances[0].id,
            doctorId: value.id,
            isContracted: value.isContracted,
            duration: value.isContracted === true ? $('#doctorAttendance_' + value.id).val() : 0
        };
    });
    
    if (updates.length !== 0) {
        let text = "هل تريد التعديل؟";
        if (confirm(text) == true) {
            var token = $('input[name="__RequestVerificationToken"]').val();
            $.ajax({
                url: `/PresenceByDay?handler=Update`,
                contentType: 'application/json',
                type: 'POST',
                data: JSON.stringify(updates),
                headers: {
                    'XSRF-TOKEN': token
                },
                success: function (response) {
                    location.reload();
                },
                error: function (xhr, status, error) {
                    console.error(error);
                }
            });
        }
    }

}

function save() {
    const table = $('#doctorsTable').DataTable();
    var rows = table
        .rows('.selected');

    var models = rows.data().toArray().map((value) => {
        return {
            doctorId: value.id,
            isContracted: value.isContracted,
            duration: value.isContracted === true ? $('#doctor_' + value.id).val() : 0
        };
    });

    //console.log(JSON.stringify(models))
    //console.log(idArray);
    if (models.length !== 0) {
        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url:  `/PresenceByDay?handler=Save`,
            contentType: 'application/json',
            type: 'POST',
            data: JSON.stringify(models),
            headers: {
                'XSRF-TOKEN': token
            },
            success: function(response){
                location.reload();
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    }
}



