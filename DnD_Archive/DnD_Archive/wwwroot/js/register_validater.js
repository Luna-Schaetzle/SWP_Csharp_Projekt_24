$(() => {

    let formOK = true;

    $("#UserName").on("blur", function () {
        let username = $("#UserName").val();

        if (usernameValidation(username)) {
            $("#username-validation").text("");
        }
        else {
            $("#username-validation").text("Der Benutzername muss mindestens 3 Zeichen lang sein.");
            formOK = false;
        }
    });

    $("#email").on("blur", function () {
        let email = $("#email").val();

        if (emailValidation(email)) {
            $("#email-validation").text("");
        }
        else {
            $("#email-validation").text("Die Email-Adresse ist nicht gültig.");
            formOK = false;
        }
    });

    $("#password").on("blur", function () {
        let password = $("#password").val();

        if (password.length < 8) {
            $("#password-validation").text("Das Passwort muss mindestens 8 Zeichen lang sein.");
            formOK = false;
        }
        else {
            $("#password-validation").text("");
        }
    });

    $("#btnsubmit").on("click", (event) => {
        $("#UserName").trigger("blur");
        $("#email").trigger("blur");
        $("#password").trigger("blur");
        
        if (!formOK) {
            event.preventDefault();
            formOK = true;
        }
        else{
            $("#register-form").submit();
        }
        
    });


});

function usernameValidation(username) {
    let us = username.trim();
  
    if (us.length < 3) {
        return false;
    }
    else{
        return true;
    }
}

function emailValidation(email) {

    var re = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (re.test(email)) {
        return true;
    } else {
        return false;
    }
}

