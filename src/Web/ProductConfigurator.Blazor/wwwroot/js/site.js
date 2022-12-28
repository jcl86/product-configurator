window.blazorExtensions = {
    SendLocalEmail: function (mailto, subject, body) {
        var link = document.createElement('a');
        var uri = "mailto:" + mailto + "?";
        if (!isEmpty(subject)) {
            uri = uri + "subject=" + subject;
        }

        if (!isEmpty(body)) {
            if (!isEmpty(subject)) { // We already appended one querystring parameter, add the '&' separator
                uri = uri + "&"
            }

            uri = uri + "body=" + body;
        }

        uri = encodeURI(uri);
        uri = uri.substring(0, 2000); // Avoid exceeding querystring limits.
        console.log('Clicking SendLocalEmail link:', uri);

        link.href = uri;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
};

function isEmpty(str) {
    return (!str || str.length === 0);
}