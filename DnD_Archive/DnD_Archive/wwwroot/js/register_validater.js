$(() => {

    let formOK = false;

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

    $("#btnsubmit").on("click", (event) => {
        $("#UserName").trigger("blur");
        $("#email").trigger("blur");
        
        if (!formOK) {
            event.preventDefault();
            formOK = true;
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

    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

    if (email.value.match(validRegex)) {
  
      //alert("Valid email address!");
      //document.form1.text1.focus();
      return true;
  
    } else {
  
      //alert("Invalid email address!");
  
      //document.form1.text1.focus();
  
      return false;
  
    }
}

