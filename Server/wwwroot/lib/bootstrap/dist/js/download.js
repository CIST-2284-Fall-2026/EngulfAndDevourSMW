// This file was written for me by ChatGPT, but the comments are my own

// Function to download a .docx file with a filename and the raw bytes
window.downloadFile = (fileName, bytes) => {
    // A blob represents raw data and can be treated as a file. The provided bytes are converted to an array for the blob object
    const blob = new Blob(
        [new Uint8Array(bytes)],
        {
            type: "application/vnd.openxmlformats-officedocument.wordprocessingml.document" // This indicates that the document is a Word document
        }
    );

    // Temporary URL that points to the blob
    const url = URL.createObjectURL(blob);

    // Creating an HTML link to that URL with the filename, then "clicks" the link, initiating the download
    const link = document.createElement("a");
    link.href = url;
    link.download = fileName;
    link.click();

    // Destroys the URL
    URL.revokeObjectURL(url);
};

// Function to download a .csv file
window.downloadCsv = (filename, csvContent) => {
    // Creating a blob, this time specifying the type to a csv file
    const blob = new Blob([csvContent], {
        type: 'text/csv;charset=utf-8;'
    });

    // Temporary URL pointing to the blob
    const url = URL.createObjectURL(blob);

    // Creating a link to the blob at that URL and "clicking" it, initiating the download
    const link = document.createElement('a');
    link.href = url;
    link.download = filename;
    link.click();

    // Destroys the URL
    URL.revokeObjectURL(url);
};