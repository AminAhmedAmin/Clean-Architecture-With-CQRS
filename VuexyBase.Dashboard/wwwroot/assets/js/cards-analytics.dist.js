/**
 * Analytics Cards
 */

'use strict';

(function () {
  let cardColor, headingColor, legendColor, labelColor, borderColor;
  if (isDarkStyle) {
    cardColor = config.colors_dark.cardColor;
    labelColor = config.colors_dark.textMuted;
    legendColor = config.colors_dark.bodyColor;
    headingColor = config.colors_dark.headingColor;
    borderColor = config.colors_dark.borderColor;
  } else {
    cardColor = config.colors.cardColor;
    labelColor = config.colors.textMuted;
    legendColor = config.colors.bodyColor;
    headingColor = config.colors.headingColor;
    borderColor = config.colors.borderColor;
  }

  // Earning Reports Bar Chart
  // --------------------------------------------------------------------
  const weeklyEarningReportsEl = document.querySelector('#weeklyEarningReports'),
    weeklyEarningReportsConfig = {
      chart: {
        height: 202,
        parentHeightOffset: 0,
        type: 'bar',
        toolbar: {
          show: false
        }
      },
      plotOptions: {
        bar: {
          barHeight: '60%',
          columnWidth: '38%',
          startingShape: 'rounded',
          endingShape: 'rounded',
          borderRadius: 4,
          distributed: true
        }
      },
      grid: {
        show: false,
        padding: {
          top: -30,
          bottom: 0,
          left: -10,
          right: -10
        }
      },
      colors: [
        config.colors_label.primary,
        config.colors_label.primary,
        config.colors_label.primary,
        config.colors_label.primary,
        config.colors.primary,
        config.colors_label.primary,
        config.colors_label.primary
      ],
      dataLabels: {
        enabled: false
      },
      series: [
        {
          data: [40, 65, 50, 45, 90, 55, 70]
        }
      ],
      legend: {
        show: false
      },
      xaxis: {
        categories: ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: labelColor,
            fontSize: '13px',
            fontFamily: 'Public Sans'
          }
        }
      },
      yaxis: {
        labels: {
          show: false
        }
      },
      tooltip: {
        enabled: false
      },
      responsive: [
        {
          breakpoint: 1025,
          options: {
            chart: {
              height: 199
            }
          }
        }
      ]
    };
  if (typeof weeklyEarningReportsEl !== undefined && weeklyEarningReportsEl !== null) {
    const weeklyEarningReports = new ApexCharts(weeklyEarningReportsEl, weeklyEarningReportsConfig);
    weeklyEarningReports.render();
  }

  // Support Tracker - Radial Bar Chart
  // --------------------------------------------------------------------
  const supportTrackerEl = document.querySelector('#supportTracker'),
    supportTrackerOptions = {
      series: [85],
      labels: ['Completed Order'],
      chart: {
        height: 360,
        type: 'radialBar'
      },
      plotOptions: {
        radialBar: {
          offsetY: 10,
          startAngle: -140,
          endAngle: 130,
          hollow: {
            size: '65%'
          },
          track: {
            background: cardColor,
            strokeWidth: '100%'
          },
          dataLabels: {
            name: {
              offsetY: -20,
              color: labelColor,
              fontSize: '13px',
              fontWeight: '400',
              fontFamily: 'Public Sans'
            },
            value: {
              offsetY: 10,
              color: headingColor,
              fontSize: '38px',
              fontWeight: '600',
              fontFamily: 'Public Sans'
            }
          }
        }
      },
      colors: [config.colors.primary],
      fill: {
        type: 'gradient',
        gradient: {
          shade: 'dark',
          shadeIntensity: 0.5,
          gradientToColors: [config.colors.primary],
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 0.6,
          stops: [30, 70, 100]
        }
      },
      stroke: {
        dashArray: 10
      },
      grid: {
        padding: {
          top: -20,
          bottom: 5
        }
      },
      states: {
        hover: {
          filter: {
            type: 'none'
          }
        },
        active: {
          filter: {
            type: 'none'
          }
        }
      },
      responsive: [
        {
          breakpoint: 1025,
          options: {
            chart: {
              height: 330
            }
          }
        },
        {
          breakpoint: 769,
          options: {
            chart: {
              height: 280
            }
          }
        }
      ]
    };
  if (typeof supportTrackerEl !== undefined && supportTrackerEl !== null) {
    const supportTracker = new ApexCharts(supportTrackerEl, supportTrackerOptions);
    supportTracker.render();
  }

  // Sales Last 6 Months - Radar Chart
  // --------------------------------------------------------------------
  const salesLastMonthEl = document.querySelector('#salesLastMonth'),
    salesLastMonthConfig = {
      series: [
        {
          name: 'Sales',
          data: [32, 27, 27, 30, 25, 25]
        },
        {
          name: 'Visits',
          data: [25, 35, 20, 20, 20, 20]
        }
      ],
      chart: {
        height: 306,
        type: 'radar',
        toolbar: {
          show: false
        }
      },
      plotOptions: {
        radar: {
          polygons: {
            strokeColors: borderColor,
            connectorColors: borderColor
          }
        }
      },
      stroke: {
        show: false,
        width: 0
      },
      legend: {
        show: true,
        fontSize: '13px',
        position: 'bottom',
        labels: {
          colors: legendColor,
          useSeriesColors: false
        },
        markers: {
          height: 10,
          width: 10,
          offsetX: -3
        },
        itemMargin: {
          horizontal: 10
        },
        onItemHover: {
          highlightDataSeries: false
        }
      },
      colors: [config.colors.primary, config.colors.info],
      fill: {
        opacity: [1, 0.85]
      },
      markers: {
        size: 0
      },
      grid: {
        show: false,
        padding: {
          top: 0,
          bottom: -5
        }
      },
      xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
        labels: {
          show: true,
          style: {
            colors: [labelColor, labelColor, labelColor, labelColor, labelColor, labelColor],
            fontSize: '13px',
            fontFamily: 'Public Sans'
          }
        }
      },
      yaxis: {
        show: false,
        min: 0,
        max: 40,
        tickAmount: 4
      },
      responsive: [
        {
          breakpoint: 769,
          options: {
            chart: {
              height: 400
            }
          }
        }
      ]
    };
  if (typeof salesLastMonthEl !== undefined && salesLastMonthEl !== null) {
    const salesLastMonth = new ApexCharts(salesLastMonthEl, salesLastMonthConfig);
    salesLastMonth.render();
  }

  // Total Revenue Report Chart - Bar Chart
  // --------------------------------------------------------------------
  const totalRevenueChartEl = document.querySelector('#totalRevenueChart'),
    totalRevenueChartOptions = {
      series: [
        {
          name: 'Earning',
          data: [270, 210, 180, 200, 250, 280, 250, 270, 150]
        },
        {
          name: 'Expense',
          data: [-140, -160, -180, -150, -100, -60, -80, -100, -180]
        }
      ],
      chart: {
        height: 350,
        parentHeightOffset: 0,
        stacked: true,
        type: 'bar',
        toolbar: { show: false }
      },
      tooltip: {
        enabled: false
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '40%',
          borderRadius: 9,
          startingShape: 'rounded',
          endingShape: 'rounded'
        }
      },
      colors: [config.colors.primary, config.colors.warning],
      dataLabels: {
        enabled: false
      },
      stroke: {
        curve: 'smooth',
        width: 6,
        lineCap: 'round',
        colors: [cardColor]
      },
      legend: {
        show: true,
        horizontalAlign: 'left',
        position: 'top',
        fontFamily: 'Public Sans',
        markers: {
          height: 12,
          width: 12,
          radius: 12,
          offsetX: -3,
          offsetY: 2
        },
        labels: {
          colors: legendColor
        },
        itemMargin: {
          horizontal: 5
        }
      },
      grid: {
        show: false,
        padding: {
          bottom: -8,
          top: 20
        }
      },
      xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep'],
        labels: {
          style: {
            fontSize: '13px',
            colors: labelColor,
            fontFamily: 'Public Sans'
          }
        },
        axisTicks: {
          show: false
        },
        axisBorder: {
          show: false
        }
      },
      yaxis: {
        labels: {
          offsetX: -16,
          style: {
            fontSize: '13px',
            colors: labelColor,
            fontFamily: 'Public Sans'
          }
        },
        min: -200,
        max: 300,
        tickAmount: 5
      },
      responsive: [
        {
          breakpoint: 1700,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '43%'
              }
            }
          }
        },
        {
          breakpoint: 1441,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '50%'
              }
            }
          }
        },
        {
          breakpoint: 1300,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '62%'
              }
            }
          }
        },
        {
          breakpoint: 991,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '38%'
              }
            }
          }
        },
        {
          breakpoint: 850,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '50%'
              }
            }
          }
        },
        {
          breakpoint: 449,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '73%'
              }
            },
            xaxis: {
              labels: {
                offsetY: -5
              }
            }
          }
        },
        {
          breakpoint: 394,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '88%'
              }
            }
          }
        }
      ],
      states: {
        hover: {
          filter: {
            type: 'none'
          }
        },
        active: {
          filter: {
            type: 'none'
          }
        }
      }
    };
  if (typeof totalRevenueChartEl !== undefined && totalRevenueChartEl !== null) {
    const totalRevenueChart = new ApexCharts(totalRevenueChartEl, totalRevenueChartOptions);
    totalRevenueChart.render();
  }

  // Total Revenue Report Budget Line Chart
  const budgetChartEl = document.querySelector('#budgetChart'),
    budgetChartOptions = {
      chart: {
        height: 100,
        toolbar: { show: false },
        zoom: { enabled: false },
        type: 'line'
      },
      series: [
        {
          name: 'Last Month',
          data: [20, 10, 30, 16, 24, 5, 40, 23, 28, 5, 30]
        },
        {
          name: 'This Month',
          data: [50, 40, 60, 46, 54, 35, 70, 53, 58, 35, 60]
        }
      ],
      stroke: {
        curve: 'smooth',
        dashArray: [5, 0],
        width: [1, 2]
      },
      legend: {
        show: false
      },
      colors: [borderColor, config.colors.primary],
      grid: {
        show: false,
        borderColor: borderColor,
        padding: {
          top: -30,
          bottom: -15,
          left: 25
        }
      },
      markers: {
        size: 0
      },
      xaxis: {
        labels: {
          show: false
        },
        axisTicks: {
          show: false
        },
        axisBorder: {
          show: false
        }
      },
      yaxis: {
        show: false
      },
      tooltip: {
        enabled: false
      }
    };
  if (typeof budgetChartEl !== undefined && budgetChartEl !== null) {
    const budgetChart = new ApexCharts(budgetChartEl, budgetChartOptions);
    budgetChart.render();
  }

  // Project Status - Line Chart
  // --------------------------------------------------------------------
  const projectStatusEl = document.querySelector('#projectStatusChart'),
    projectStatusConfig = {
      chart: {
        height: 252,
        type: 'area',
        toolbar: false
      },
      markers: {
        strokeColor: 'transparent'
      },
      series: [
        {
          data: [2000, 2000, 4000, 4000, 3050, 3050, 2000, 2000, 3050, 3050, 4700, 4700, 2750, 2750, 5700, 5700]
        }
      ],
      dataLabels: {
        enabled: false
      },
      grid: {
        show: false,
        padding: {
          left: -10,
          right: -5
        }
      },
      stroke: {
        width: 3,
        curve: 'straight'
      },
      colors: [config.colors.primary],
      fill: {
        type: 'gradient',
        gradient: {
          opacityFrom: 0.6,
          opacityTo: 0.15,
          stops: [0, 95, 100]
        }
      },
      xaxis: {
        labels: {
          show: false
        },
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        lines: {
          show: false
        }
      },
      yaxis: {
        labels: {
          show: false
        },
        min: 1000,
        max: 6000,
        tickAmount: 5
      },
      tooltip: {
        enabled: false
      }
    };
  if (typeof projectStatusEl !== undefined && projectStatusEl !== null) {
    const projectStatus = new ApexCharts(projectStatusEl, projectStatusConfig);
    projectStatus.render();
  }

  // Earning Reports Tabs Function
  function EarningReportsBarChart(arrayData, highlightData) {
    const basicColor = config.colors_label.primary,
      highlightColor = config.colors.primary;
    var colorArr = [];

    for (let i = 0; i < arrayData.length; i++) {
      if (i === highlightData) {
        colorArr.push(highlightColor);
      } else {
        colorArr.push(basicColor);
      }
    }

    const earningReportBarChartOpt = {
      chart: {
        height: 258,
        parentHeightOffset: 0,
        type: 'bar',
        toolbar: {
          show: false
        }
      },
      plotOptions: {
        bar: {
          columnWidth: '32%',
          startingShape: 'rounded',
          borderRadius: 7,
          distributed: true,
          dataLabels: {
            position: 'top'
          }
        }
      },
      grid: {
        show: false,
        padding: {
          top: 0,
          bottom: 0,
          left: -10,
          right: -10
        }
      },
      colors: colorArr,
      dataLabels: {
        enabled: true,
        formatter: function (val) {
          return val + 'k';
        },
        offsetY: -25,
        style: {
          fontSize: '15px',
          colors: [legendColor],
          fontWeight: '600',
          fontFamily: 'Public Sans'
        }
      },
      series: [
        {
          data: arrayData
        }
      ],
      legend: {
        show: false
      },
      tooltip: {
        enabled: false
      },
      xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep'],
        axisBorder: {
          show: true,
          color: borderColor
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: labelColor,
            fontSize: '13px',
            fontFamily: 'Public Sans'
          }
        }
      },
      yaxis: {
        labels: {
          offsetX: -15,
          formatter: function (val) {
            return '$' + parseInt(val / 1) + 'k';
          },
          style: {
            fontSize: '13px',
            colors: labelColor,
            fontFamily: 'Public Sans'
          },
          min: 0,
          max: 60000,
          tickAmount: 6
        }
      },
      responsive: [
        {
          breakpoint: 1441,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '41%'
              }
            }
          }
        },
        {
          breakpoint: 590,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '61%',
                borderRadius: 5
              }
            },
            yaxis: {
              labels: {
                show: false
              }
            },
            grid: {
              padding: {
                right: 0,
                left: -20
              }
            },
            dataLabels: {
              style: {
                fontSize: '12px',
                fontWeight: '400'
              }
            }
          }
        }
      ]
    };
    return earningReportBarChartOpt;
  }
  var chartJson = 'earning-reports-charts.json';
  // Earning Chart JSON data
  var earningReportsChart = $.ajax({
    url: assetsPath + 'json/' + chartJson, //? Use your own search api instead
    dataType: 'json',
    async: false
  }).responseJSON;

  // Earning Reports Tabs Orders
  // --------------------------------------------------------------------
  const earningReportsTabsOrdersEl = document.querySelector('#earningReportsTabsOrders'),
    earningReportsTabsOrdersConfig = EarningReportsBarChart(
      earningReportsChart['data'][0]['chart_data'],
      earningReportsChart['data'][0]['active_option']
    );
  if (typeof earningReportsTabsOrdersEl !== undefined && earningReportsTabsOrdersEl !== null) {
    const earningReportsTabsOrders = new ApexCharts(earningReportsTabsOrdersEl, earningReportsTabsOrdersConfig);
    earningReportsTabsOrders.render();
  }
  // Earning Reports Tabs Sales
  // --------------------------------------------------------------------
  const earningReportsTabsSalesEl = document.querySelector('#earningReportsTabsSales'),
    earningReportsTabsSalesConfig = EarningReportsBarChart(
      earningReportsChart['data'][1]['chart_data'],
      earningReportsChart['data'][1]['active_option']
    );
  if (typeof earningReportsTabsSalesEl !== undefined && earningReportsTabsSalesEl !== null) {
    const earningReportsTabsSales = new ApexCharts(earningReportsTabsSalesEl, earningReportsTabsSalesConfig);
    earningReportsTabsSales.render();
  }
  // Earning Reports Tabs Profit
  // --------------------------------------------------------------------
  const earningReportsTabsProfitEl = document.querySelector('#earningReportsTabsProfit'),
    earningReportsTabsProfitConfig = EarningReportsBarChart(
      earningReportsChart['data'][2]['chart_data'],
      earningReportsChart['data'][2]['active_option']
    );
  if (typeof earningReportsTabsProfitEl !== undefined && earningReportsTabsProfitEl !== null) {
    const earningReportsTabsProfit = new ApexCharts(earningReportsTabsProfitEl, earningReportsTabsProfitConfig);
    earningReportsTabsProfit.render();
  }
  // Earning Reports Tabs Income
  // --------------------------------------------------------------------
  const earningReportsTabsIncomeEl = document.querySelector('#earningReportsTabsIncome'),
    earningReportsTabsIncomeConfig = EarningReportsBarChart(
      earningReportsChart['data'][3]['chart_data'],
      earningReportsChart['data'][3]['active_option']
    );
  if (typeof earningReportsTabsIncomeEl !== undefined && earningReportsTabsIncomeEl !== null) {
    const earningReportsTabsIncome = new ApexCharts(earningReportsTabsIncomeEl, earningReportsTabsIncomeConfig);
    earningReportsTabsIncome.render();
  }

  // Total Earning Chart - Bar Chart
  // --------------------------------------------------------------------
  const totalEarningChartEl = document.querySelector('#totalEarningChart'),
    totalEarningChartOptions = {
      series: [
        {
          name: 'Earning',
          data: [15, 10, 20, 8, 12, 18, 12, 5]
        },
        {
          name: 'Expense',
          data: [-7, -10, -7, -12, -6, -9, -5, -8]
        }
      ],
      chart: {
        height: 225,
        parentHeightOffset: 0,
        stacked: true,
        type: 'bar',
        toolbar: { show: false }
      },
      tooltip: {
        enabled: false
      },
      legend: {
        show: false
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '18%',
          borderRadius: 5,
          startingShape: 'rounded',
          endingShape: 'rounded'
        }
      },
      colors: [config.colors.danger, config.colors.primary],
      dataLabels: {
        enabled: false
      },
      grid: {
        show: false,
        padding: {
          top: -40,
          bottom: -20,
          left: -10,
          right: -2
        }
      },
      xaxis: {
        labels: {
          show: false
        },
        axisTicks: {
          show: false
        },
        axisBorder: {
          show: false
        }
      },
      yaxis: {
        labels: {
          show: false
        }
      },
      responsive: [
        {
          breakpoint: 1468,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '22%'
              }
            }
          }
        },
        {
          breakpoint: 1197,
          options: {
            chart: {
              height: 228
            },
            plotOptions: {
              bar: {
                borderRadius: 8,
                columnWidth: '26%'
              }
            }
          }
        },
        {
          breakpoint: 783,
          options: {
            chart: {
              height: 232
            },
            plotOptions: {
              bar: {
                borderRadius: 6,
                columnWidth: '28%'
              }
            }
          }
        },
        {
          breakpoint: 589,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '16%'
              }
            }
          }
        },
        {
          breakpoint: 520,
          options: {
            plotOptions: {
              bar: {
                borderRadius: 6,
                columnWidth: '18%'
              }
            }
          }
        },
        {
          breakpoint: 426,
          options: {
            plotOptions: {
              bar: {
                borderRadius: 5,
                columnWidth: '20%'
              }
            }
          }
        },
        {
          breakpoint: 381,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '24%'
              }
            }
          }
        }
      ],
      states: {
        hover: {
          filter: {
            type: 'none'
          }
        },
        active: {
          filter: {
            type: 'none'
          }
        }
      }
    };
  if (typeof totalEarningChartEl !== undefined && totalEarningChartEl !== null) {
    const totalEarningChart = new ApexCharts(totalEarningChartEl, totalEarningChartOptions);
    totalEarningChart.render();
  }
})();
