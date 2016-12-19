ko.extenders.numeric = function (target, precision) {
    //create a writable computed observable to intercept writes to our observable
    var result = ko.pureComputed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target(),
                    roundingMultiplier = Math.pow(10, precision),
                    newValueAsNum = isNaN(newValue) ? current : parseFloat(+newValue),
                    valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            //only write if it changed
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
                //if the rounded value is the same, but a different value was written, force a notification for the current field
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    }).extend({ notify: 'always' });

    //initialize with current value to make sure it is rounded appropriately
    result(target());

    //return the new computed observable
    return result;
};

function NotificationSuccess(message) {
    var not = $.Notify({
        content: message,
        timeout: 3500,
        style: { background: 'green', color: 'white' }
    });
}

function NotificationFail(message) {
    var not = $.Notify({
        content: message,
        timeout: 3500,
        style: { background: 'brown', color: 'white' }
    });
}

function PopupConfirm(title, message, onOK, onCancel) {

    var dialog = $("#popupConfirm");
    $("#popupConfirm .message").html(message);

    $.Dialog({
        overlay: true,
        shadow: true,
        flat: true,
        padding: 10,
        title: title == undefined ? "" : title,
        content: $(dialog).html(),
        width: 500,
        onShow: function (dialog) {

            $(dialog).find(".okButton").unbind("click").click(function () {

                $.Dialog.close();

                if (onOK != undefined)
                    onOK();
            });

            $(dialog).find(".cancelButton").unbind("click").click(function () {

                $.Dialog.close();

                if (onCancel != undefined)
                    onCancel();
            });

        }

    });

}

function PopupAlert(title, message, onOK) {
    var dialog = $("#popupAlert");
    $("#popupAlert .message").html(message);

    $.Dialog({
        overlay: true,
        shadow: true,
        flat: true,
        padding: 10,
        title: title == undefined ? "" : title,
        content: $(dialog).html(),
        width: 500,
        onShow: function (dialog) {

            $(dialog).find(".okButton").unbind("click").click(function () {

                $.Dialog.close();

                if (onOK != undefined)
                    onOK();
            });
        }

    });
}