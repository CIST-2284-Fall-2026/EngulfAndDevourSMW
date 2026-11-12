// This file was written for me by ChatGPT, but the comments are my own

// ExpenditureChart represents an HTML element for the canvas
let expenditureChart = null;

// Function to create the chart with a list of decimal values
window.createExpenditureChart = (values) => {
    // Setting the element context to the ctx variable
    const ctx = document.getElementById('expenditureChart');

    // If the context doesn't exist, stops making the chart
    if (!ctx) return;

    // Creating a new chart (using the chart.js CDN)
    // The first parameter is the context. The second is an object containing chart properties
    expenditureChart = new Chart(ctx, {
        // Line chart
        type: 'line',
        // Creating labels 
        data: {
            // Creates an array of labels based on the index of each array in values. The labels will read year 1-30
            labels: values.map((_, i) => `Year ${i + 1}`),
            // The title is Annual Expenditures, the provided data is the values array
            datasets: [{
                label: 'Annual Expenditures',
                data: values,
                borderWidth: 2
            }]
        },
        // This allows the chart to stretch and shrink to its container size
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
};

// Function to update an existing chart
window.updateExpenditureChart = (values) => {
    // If the element exists, remaps the labels and provides the new list of values, then calls update
    if (expenditureChart) {
        expenditureChart.data.labels =
            values.map((_, i) => `Year ${i + 1}`);

        expenditureChart.data.datasets[0].data = values;

        expenditureChart.update();
    }
};

// Function to destroy an existing chart
window.destroyExpenditureChart = () => {
    const chart = Chart.getChart('expenditureChart');

    if (chart) {
        chart.destroy();
    }

    expenditureChart = null;
};