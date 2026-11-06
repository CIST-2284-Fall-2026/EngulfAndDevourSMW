let expenditureChart = null;

window.createExpenditureChart = (values) => {
    const ctx = document.getElementById('expenditureChart');

    expenditureChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: values.map((_, i) => `Year ${i + 1}`),
            datasets: [{
                label: 'Annual Expenditures',
                data: values,
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
};

window.updateExpenditureChart = (values) => {
    if (expenditureChart) {
        expenditureChart.data.labels =
            values.map((_, i) => `Year ${i + 1}`);

        expenditureChart.data.datasets[0].data = values;

        expenditureChart.update();
    }
};

window.destroyExpenditureChart = () => {
    if (expenditureChart) {
        expenditureChart.destroy();
        expenditureChart = null;
    }
};