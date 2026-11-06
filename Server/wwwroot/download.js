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