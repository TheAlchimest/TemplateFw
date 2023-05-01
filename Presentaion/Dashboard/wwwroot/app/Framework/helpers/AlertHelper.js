var alertHelper = {
        success: function (title, msg) {
            swal.fire(title, msg, "success");
        },
        warning: function (title, msg) {;
            swal.fire(title, msg, "warning");
        },
        error: function (title, msg) {
            swal.fire(title, msg, "error");
        },
        multiLine: function (title, msgArr,type) {
            let msg = ''
            msgArr.forEach(function (element, index) {
                msg += `<li>${element}</li>`;
            });
            msg = `<ul>${msg}</ul>`;
            swal.fire(title, msg, type)
        },
        showResponse: function (webResponse, status, xhr,onsuccess) {
            console.log("webResponse", webResponse);
            console.log("status", status);
            console.log("xhr", xhr);
            console.log(webResponse);
            if (webResponse.Status) {
                if (webResponse.Messages != null && webResponse.Messages.length > 1) {
                    alertHelper.multiLine("", webResponse.Messages, "success");
                }
                if (webResponse.Messages != null && webResponse.Messages.length > 0) {
                    alertHelper.success(webResponse.Messages.join(), "");
                }
                // additions 
                if (typeof onsuccess !== "undefined" && onsuccess != null ) {
                    onsuccess();
                }

            } else {
                if (webResponse.Messages != null && webResponse.Messages.length > 1) {
                    alertHelper.multiLine("", webResponse.Messages, "error");
                }
                if (webResponse.Messages != null && webResponse.Messages.length > 0) {
                    alertHelper.error(webResponse.Messages.join(), "");
                }
                if (webResponse.Errors != null && webResponse.Messages.length > 0) {
                    for (var i = 0; i < webResponse.Errors.length; i++) {
                        var error = webResponse.Errors[i];
                        $.smkAddError($("#" + error.PropertyName), error.ErrorMessage);
                    }

                }
            }
        }
        ,
        showResponse2: function (webResponse, status, xhr, redirecturl) {
            console.log("webResponse", webResponse);
            console.log("status", status);
            console.log("xhr", xhr);
            console.log(webResponse);
            if (webResponse.Status) {
                if (webResponse.Message != null && webResponse.Message.length > 0) {
                    swal.fire(webResponse.Message, "", "success").then((result) => {
                        /* Read more about isConfirmed, isDenied below */
                        if (result.isConfirmed) {
                            window.location = redirecturl;
                        } 
                    });
                }
                // additions 
                if (typeof onsuccess !== "undefined" && onsuccess != null ) {
                    onsuccess();
                }

            } else {
                if (webResponse.Messages != null && webResponse.Messages.length > 1) {
                    alertHelper.multiLine("خطأ", webResponse.Messages, "error");
                }
                if (webResponse.Messages != null && webResponse.Messages.length > 0) {
                    alertHelper.error(webResponse.Messages.join(), "");
                }
            }
        }
};

