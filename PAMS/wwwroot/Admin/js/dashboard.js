$(function () {
    var breakup = {
        series: [50, 30, 20],
        labels: ["Projects", "Audits", "Pending Reviews"],
        chart: {
            type: 'donut',
            width: 260,
            fontFamily: "'Inter', sans-serif",
            foreColor: "#adb5bd"
        },
        colors: ["#198754", "#0d6efd", "#ffc107"], 
        plotOptions: {
            pie: {
                donut: {
                    size: '75%',
                    labels: {
                        show: true,
                        name: {
                            fontSize: '14px',
                            fontWeight: 600,
                            color: '#6c757d'
                        },
                        value: {
                            fontSize: '22px',
                            fontWeight: 700,
                            color: '#343a40'
                        },
                        total: {
                            show: true,
                            label: 'Total',
                            fontSize: '14px',
                            color: '#6c757d',
                            formatter: function (w) {
                                return w.globals.seriesTotals.reduce((a, b) => a + b, 0);
                            }
                        }
                    }
                }
            }
        },
        dataLabels: {
            enabled: true,
            style: {
                fontSize: '13px'
            }
        },
        legend: {
            position: 'bottom',
            fontSize: '13px',
            labels: {
                colors: '#adb5bd'
            },
            markers: {
                width: 10,
                height: 10,
                radius: 2
            }
        },
        tooltip: {
            theme: "dark",
            y: {
                formatter: function (value, { w, seriesIndex }) {
                    return w.config.labels[seriesIndex] + ": " + value;
                }
            }
        },
        responsive: [
            {
                breakpoint: 768,
                options: {
                    chart: {
                        width: 220
                    }
                }
            }
        ]
    };

    var chart = new ApexCharts(document.querySelector("#breakup"), breakup);
    chart.render();
    

    var monthlyTasks = {
        chart: {
            id: "sparkline-tasks",
            type: "area",
            height: 100,
            sparkline: { enabled: true },
            fontFamily: "'Inter', sans-serif",
            foreColor: "#adb5bd"
        },
        series: [{
            name: "Tasks Completed",
            data: [12, 20, 18, 25, 22, 28, 30] 
        }],
        stroke: {
            curve: "smooth",
            width: 3,
            lineCap: "round",
            colors: ["#0d6efd"]
        },
        fill: {
            type: "gradient",
            gradient: {
                shade: "dark",
                type: "vertical",
                shadeIntensity: 0.5,
                gradientToColors: ["#cfe2ff"],
                inverseColors: false,
                opacityFrom: 0.5,
                opacityTo: 0,
                stops: [0, 100]
            }
        },
        markers: {
            size: 0
        },
        tooltip: {
            theme: "dark",
            y: {
                formatter: function (val) {
                    return val + " Tasks";
                }
            }
        },
        grid: {
            show: false
        },
        xaxis: {
            type: 'datetime',
            categories: [
                '2025-01-01', '2025-01-02', '2025-01-03',
                '2025-01-04', '2025-01-05', '2025-01-06', '2025-01-07'
            ],
            labels: { show: false }
        },
        yaxis: {
            show: false
        }
    };
    new ApexCharts(document.querySelector("#earning"), monthlyTasks).render();
});