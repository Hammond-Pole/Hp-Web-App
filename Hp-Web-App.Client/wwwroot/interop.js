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

window.downloadFile = (fileUrl, fileName) => {
    const link = document.createElement("a");
    link.href = fileUrl;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};

function saveAsFile(fileName, base64String) {
    var link = document.createElement('a');
    link.download = fileName;
    link.href = 'data:application/octet-stream;base64,' + base64String;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
