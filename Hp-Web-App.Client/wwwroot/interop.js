window.blazorHelpers = {
    clearSession: function () {
        sessionStorage.clear();
    },

    closeBrowser: function () {
        window.open('', '_self', '');
        window.close();
    },

    refresh: function () {
        location.reload();
    }
};
