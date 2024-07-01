// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*
  onclick page go to homepage without any absolute path
  -https://stackoverflow.com/questions/12564999/onclick-page-go-to-homepage-without-any-absolute-path
*/
function GoToHomePage() {
    window.location = '/';
}

/*=================================================================================================================*/
/*
  Enable tooltips everywhere
  One way to initialize all tooltips on a page would be to select them by their data-bs-toggle attribute:
  -https://getbootstrap.com/docs/5.0/components/tooltips/
*/
//$(function () { 
//    $('[data-taggle="tooltip"]').tooltip()
//})

//var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
//var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
//    return new bootstrap.Tooltip(tooltipTriggerEl)
//})

//var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
//var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
//    return new bootstrap.Tooltip(tooltipTriggerEl, {
//        'customClass': 'custom-tooltip'
//    })
//})

/*=================================================================================================================*/
/*
  Table Filter Using JavaScript
  -https://www.vrsofttech.com/code-editor/js/index?file_name=js-filter-table
*/

var table = document.querySelector("#filterTable");

var input = document.createElement("input");
input.setAttribute("id", "filterSearch");
input.setAttribute("type", "text");
input.setAttribute("placeholder", "Search...");
table.parentNode.insertBefore(input, table);

var td, txtValue;
input.onkeyup = function () {
    var filter = input.value.toUpperCase();
    var tr = table.querySelector("tbody").querySelectorAll("tr");

    for (let i = 0; i < tr.length; i++) {
        txtValue = tr[i].textContent || tr[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
}

/*
-https://stackoverflow.com/questions/66990691/tooltips-and-popovers-not-working-in-bootstrap-5
*/
$(function () { 
    $('[data-taggle="tooltip"]').tooltip()
})

const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.tooltip(tooltipTriggerEl))

//------------------------------------------------------------------------------------------------------------------
/**
 * htpps://stackoverflow.com/questions/10211145/getting-current-date-and-time-on-javascript
 * 
<style>
  sup {
        vertical-align: super;
        font-size: smaller;
    }
 </style>

<html>
  <body onload="startTime()">
    <div id="txt"></div>
  </body>
</html>
 */
function startTime() {
    var today = new Date();
    //                   1    2    3    4    5    6    7    8    9   10    11  12   13   14   15   16   17   18   19   20   21   22   23   24   25   26   27   28   29   30   31   32   33
    var suffixes = ['', 'st', 'nd', 'rd', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'st', 'nd', 'rd', 'th', 'th', 'th', 'th', 'th', 'th', 'th', 'st', 'nd', 'rd'];

    var weekday = new Array(7);
    weekday[0] = "Sunday";
    weekday[1] = "Monday";
    weekday[2] = "Tuesday";
    weekday[3] = "Wednesday";
    weekday[4] = "Thursday";
    weekday[5] = "Friday";
    weekday[6] = "Saturday";

    var month = new Array(12);
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";

    document.getElementById('txt').innerHTML = (weekday[today.getDay()] + ',' + " " + today.getDate() + '<sup>' + suffixes[today.getDate()] + '</sup>' + ' of' + " " + month[today.getMonth()] + " " + today.getFullYear() + ' Time Now ' + today.toLocaleTimeString());
    t = setTimeout(function () { startTime() }, 500);
}
//------------------------------------------------------------------------------------------------------------------