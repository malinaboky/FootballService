function GetChanges(id) {
    document.getElementById(id).setAttribute('type', 'button');
}

function SaveChanges(idRow, id) {
    let row = document.querySelectorAll(`#${idRow} > td > input[type="text"], #${idRow} > td > select`);
    let data = {}

    $.each(row, function (i, l) {
        if (l.tagName == 'SELECT') {
            data[l.name] = parseInt(l.value)
        }
        else {
            data[l.name] = l.value
        }
    });

    data['id'] = id

    jQuery.ajax({
        url: 'EditPlayer',
        type: 'POST',
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            jQuery('#edit' + id).html(result.html);

            var isTrueSet = result.flag;

            if (isTrueSet) {
                $("#success").slideDown('slow');
                setTimeout(function () { $("#success").slideUp('slow'); }, 500);
            }
            else {
                $("#error").slideDown('slow');
                setTimeout(function () { $("#error").slideUp('slow'); }, 2000);
            }
        }

    }).fail(function (response) {
        let data = jQuery.parseJSON(response.responseText)
        let el = document.querySelector("#server-error > p");
        el.textContent = data.message;
        if (parseInt(data.code) == 404) {
            document.getElementById(idRow).remove();            
        }
        else {
            el.textContent += " Пожалуйста, повторите попытку позже.";
        }
        $("#server-error").slideDown('slow');
        setTimeout(function () { $("#server-error").slideUp('slow'); }, 1000);
    });
}


function Delete(htmlId, id) {
    let row = document.getElementById(htmlId);
    let data = {}

    data['id'] = id

    jQuery.ajax({
        url: 'DeletePlayer',
        type: 'DELETE',
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            row.remove();
        },

        error: function (response) {
            let data = jQuery.parseJSON(response.responseText)
            let el = document.querySelector("#server-error > p");
            el.textContent = data.message;
            if (parseInt(data.code) == 404) {
                row.remove();               
            }
            else {
                el.textContent += " Пожалуйста, повторите попытку позже.";
            }
            $("#server-error").slideDown('slow');
            setTimeout(function () { $("#server-error").slideUp('slow'); }, 1000);
        }
    });
}

function GetBack() {
    history.go(-1);
    return false;
}