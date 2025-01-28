// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
const errorMessage = (day, month, year) => {
    var currentDate = new Date();

    // Get the current month (returns a number from 0 to 11)
    var currentMonth = currentDate.getMonth();
    var currentYear = currentDate.getFullYear();

    var div = document.getElementById('demo');
    if (year > currentYear || month > currentMonth) {
        div.style.display = 'block';
        div.innerHTML = `No presence registration for month ${(month + 1)}`;
        //console.log(month + " " + currentMonth)
    }
    else {
        try {
            var date = new Date(year, month, day); // Replace with your actual date
            //alert(date);
            var url = '/PresenceByDay?encodedDate=' + encodeURIComponent(date.toISOString());

            // Navigate to the PresenceByDay page
            window.location.href = url;
        }
        catch (e) {
            console.log(e.errorMessage);
        }
        //window.location.href = `?day=${day}&month=${month+1}&year=${year}`;
    }

}

const daysTag = document.querySelector(".days"),
    currentDate = document.querySelector(".current-date"),
    prevNextIcon = document.querySelectorAll(".icons span");

// getting new date, current year and month
let date = new Date(),
    currYear = date.getFullYear(),
    currMonth = date.getMonth();

// storing full name of all months in array
const months = ["January", "February", "March", "April", "May", "June", "July",
    "Augest", "September", "October", "November", "December"];



const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting first day of month
        lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
        lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
        lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month
    let liTag = "";

    for (let i = firstDayofMonth; i > 0; i--) { // creating li of previous month last days
        liTag += `<li class="inactive">${(lastDateofLastMonth - i + 1) }</li>`;
    }

    for (let i = 1; i <= lastDateofMonth; i++) { // creating li of all days of current month
        // adding active class to li if the current day, month, and year matched
        let isToday = i === date.getDate() && currMonth === new Date().getMonth()
            && currYear === new Date().getFullYear() ? "btn-primary" : "text-black";
        liTag += `<li ><button class="btn text-decoration-none ${isToday} rounded-circle p-2" type="submit"
        onclick="errorMessage(${i}, ${currMonth}, ${currYear})" >
            ${ i    }
            </button ></li>`;
    } 

    for (let i = lastDayofMonth; i < 6; i++) { // creating li of next month first days
        liTag += `<li class="inactive" asp-page="/Calendar">${(i - lastDayofMonth + 1) }</li>`
    }
    currentDate.innerText = `${months[currMonth]} ${currYear }`; // passing current mon and yr as currentDate text
    daysTag.innerHTML = liTag;
}

prevNextIcon.forEach(icon => { // getting prev and next icons
    icon.addEventListener("click", () => { // adding click event on both icons
        // if clicked icon is previous icon then decrement current month by 1 else increment it by 1
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if (currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
            // creating a new date of current year & month and pass it as date value
            date = new Date(currYear, currMonth, new Date().getDate());
            currYear = date.getFullYear(); // updating current year with new date year
            currMonth = date.getMonth(); // updating current month with new date month
        } else {
            date = new Date(); // pass the current date as date value
        }
        renderCalendar(); // calling renderCalendar function
    });
});