// Warten, bis das DOM vollständig geladen ist
document.addEventListener("DOMContentLoaded", function () {
    // Elemente im DOM abrufen
    var cookieConsent = document.getElementById('cookieConsent');
    var acceptCookiesButton = document.getElementById('acceptCookies');

    // Funktion, um das Cookie zu setzen
    function setCookie(name, value, days) {
        var expires = "";
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toUTCString();
        }
        document.cookie = name + "=" + (value || "") + expires + "; path=/";
    }

    // Funktion, um ein Cookie zu lesen
    function getCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    // Überprüfen, ob der Benutzer die Cookies akzeptiert hat
    if (!getCookie('cookiesAccepted')) {
        cookieConsent.style.display = 'block';
    } else {
        cookieConsent.style.display = 'none';
    }

    // Wenn der Benutzer die Cookies akzeptiert, das Popup ausblenden und ein Cookie setzen
    acceptCookiesButton.addEventListener('click', function () {
        setCookie('cookiesAccepted', 'true', 365);
        cookieConsent.style.display = 'none';
    });
});
