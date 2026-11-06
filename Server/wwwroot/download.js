window.downloadFile = (fileName, bytes) => {
    const blob = new Blob(
        [new Uint8Array(bytes)],
        {
            type: "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        }
    );

    const url = URL.createObjectURL(blob);

    const link = document.createElement("a");
    link.href = url;
    link.download = fileName;
    link.click();

    URL.revokeObjectURL(url);
};

window.downloadCsv = (filename, csvContent) => {
    const blob = new Blob([csvContent], {
        type: 'text/csv;charset=utf-8;'
    });

    const url = URL.createObjectURL(blob);

    const link = document.createElement('a');
    link.href = url;
    link.download = filename;

    link.click();

    URL.revokeObjectURL(url);
};