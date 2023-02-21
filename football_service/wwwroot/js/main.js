function addNewTeam() {
    document.getElementById('danger').textContent = "";
    document.getElementById('new-team').className = "hide"; 
    document.getElementById('add-new-team').className = "";
}

function deleteNewTeam() {
    document.getElementById('new-team').className = "";
    document.getElementById('add-new-team').className = "hide";
}

document.addEventListener("DOMContentLoaded", GetMessage);

function GetMessage() {
    let el = document.querySelector('#success > p');
    if (el != null) {
        $("#success").slideDown('slow');
        setTimeout(function () { $("#success").slideUp('slow'); }, 500);
    }
}

function AddTeam() {
    let name = document.getElementById("text-team").value;

    jQuery.ajax({
        url: 'MainPage/AddTeam',
        type: 'POST',
        data: JSON.stringify({ newteam: name }),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            jQuery('#add-team-container').html(result);
        },

        error: function (response) {
            deleteNewTeam();
            let data = jQuery.parseJSON(response.responseText)
            document.getElementById('error').textContent = data.message + " Пожалуйста, повторите попытку позже.";
            document.getElementById('error').className = "";
        }
    });
}

