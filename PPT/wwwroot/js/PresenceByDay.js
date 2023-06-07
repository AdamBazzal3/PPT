
var doctors = [];
var listSet;

// Function to handle the click event of the "Add Attendance" button
function removeAttendance(button, id, date) {
    const row = button.parentNode.parentNode;
    row.remove();
    alert(id + " " + date)
    var dateObject = new Date(date);
    var token = $('input[name="__RequestVerificationToken"]').val();
    $.ajax({
        url: `/PresenceByDay?handler=Delete&DoctorId=${id}&date=${date}`,
        type: 'POST',
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
            $.each(data, function (i, instance) {
                doctors.push(instance);
            });

            doctors.forEach(function (doctor) {
                console.log(doctor.name);
            })
        });
    

    } else {
        div.style.display = "none";
        overlay.style.display = "none";
    }
}
