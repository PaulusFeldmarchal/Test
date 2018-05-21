$("#addBtn").click(function () {
    $("#modalAdd").css("display","block");
});
$("#closeAddModal").click(function () {
    $("#modalAdd").css("display", "none");
});

$("#closeEditModal").click(function () {
    $("#modalEdit").css("display", "none");
});

$(window).click(function (event) {
    if (event.target === $("#modalAdd").get(0) || event.target === $("#modalEdit").get(0)) {
        $("#modalAdd").css("display", "none");
        $("#modalEdit").css("display", "none");
    }
});

$("#syncBtn").click(function () {/////
    event.preventDefault();
    $.ajax({
        url: "/Sync",
        type: "POST"
    });
});

$("#addForm").submit(function (event) {
    event.preventDefault();
    var post_url = "/Home/Add";
    var request_method = $(this).attr("method");
    var form_data = $(this).serialize();

    $.ajax({
        url: post_url,
        type: request_method,
        data: form_data
    }).done(function (response) {
        location.reload();
    });
});

$("#editForm").submit(function (event) {
    event.preventDefault();
    var post_url = "/Home/Edit";
    var request_method = $(this).attr("method");
    var form_data = $(this).serialize();

    $.ajax({
        url: post_url,
        type: request_method,
        data: form_data
    }).done(function (response) {
        location.reload();
    });
});

$(".deleteBtn").click(function () {
    deleteItem(this.value);
});

$(".editBtn").click(function () {
    editItem(this.value);
}); 


function editItem(id) {
    modalEdit.style.display = "block";
    $.ajax({
        url: "/Home/GetUser",
        type: "GET",
        data: { id: id },
        dataType: "json",
        success: function (result) {
            $("#idE").val(result.id);
            $("#firstNameE").val(result.firstName);
            $("#lastNameE").val(result.lastName);
            $("#ageE").val(result.age);
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: "/Home/Delete",
        type: "POST",
        data: { id: id },
        dataType: "json",
        success: function () {
            location.reload();
        }
    });
}