
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

function toggle() {
    var div = document.getElementById("popup");
    var overlay = document.getElementById("overlay");
    

    if (div.style.display === "none") {
        div.style.display = "block";
        overlay.style.display = "block";
        //console.log(doctors);
        
        if (doctors.length === 0) {
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
                            }
                        },
                        data: data,
                        columns: [
                            { title: '#', data: 'id' },
                            { title: 'university id', data: 'universityId' },
                            { title: 'الاسم', data: 'name' },
                            {
                                title: 'contracted',
                                data: 'isContracted',
                                render: function (data, type, row) {
                                    var disabled = 'disabled';
                                    console.log(data);
                                    if (data && data == true)
                                        disabled = '';
                                    return `<input  type="Number" placeholder="" value="" id="price" class='form-control' name="duration" ${disabled}  min="1" value="1"/>`;
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
                    table.data(data);
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
        }
        /*
        <th>id</th>
                    <th>university id</th>
                    <th>is contracted</th>
                    <th>Name</th>
                    <th>Select</th>
        */
    } else {
        div.style.display = "none";
        overlay.style.display = "none";
    }
}

function save() {
    const table = $('#doctorsTable').DataTable();

    if (doctors.length !== 0) {
        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url: `/PresenceByDay?handler=Doctors`,
            type: 'POST',
            headers: {
                'XSRF-TOKEN': token
            },
            error: function (xhr, status, error) {
                console.error('Failed to remove presence');
            }
        }).done(function (data) {

            $.each(data, function (i, instance) {
                doctors.push(instance);
            });
            //console.log(doctors)

            $.each(doctors, function (i, instance) {

                table.row.add([instance.id, instance.universityId, instance.isContracted, instance.name, `<input class="form-check-input" type="checkbox" value="">`]).draw(false)
            })
            //table.draw();

        });
    }

}

