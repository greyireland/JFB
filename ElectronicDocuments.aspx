<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="ElectronicDocuments.aspx.cs" Inherits="ElectronicDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_SelfInfo.css" rel="stylesheet" />
    <link href="Css/Css_E_Doc.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div style="width: 100%;">
        <div class="e-sub-toolbar">
            <a>交易记录</a>
            <a>充值记录</a>
            <a class="click">电子对账单</a>
        </div>
        <div class="e-sub-content">
            <div>
                <div class="e-sub-exchange e-sub-default">
                    <div class="e-sub-subtitlebar e-sub-shou"></div>
                    <div class="e-sub-subtitle">
                        <table>
                            <tr>
                                <td>
                                    <div class="dhmq shou"></div>
                                </td>
                                <td>
                                    <div><span class="float-big"><%=PageHelper.SpliteInt(income) %>.</span><span class="float-small"><%=PageHelper.SpliteFloat(income) %></span></div>
                                </td>
                                <td>
                                    <div>收入</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="e-sub-contitle">
                        <span>收入</span>
                    </div>
                    <div>
                        <div id="e-sub-in-chart" class="e-sub-chart" style="height: 300px; display: block; margin: 10px;"></div>
                    </div>
                </div>

                <div class="e-sub-credit e-sub-default">
                    <div class="e-sub-subtitlebar e-sub-zhi"></div>
                    <div class="e-sub-subtitle">
                        <table>
                            <tr>
                                <td>
                                    <div class="dhmq zhi"></div>
                                </td>
                                <td>
                                    <div><span class="float-big"><%=PageHelper.SpliteInt(expend) %>.</span><span class="float-small"><%=PageHelper.SpliteFloat(expend) %></span></div>
                                </td>
                                <td>
                                    <div>支出</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="e-sub-contitle">
                        <span>支出</span>
                    </div>
                    <div id="e-sub-ex-chart" class="e-sub-chart" style="height: 300px; display: block;">
                    </div>
                </div>


            </div>
            <div>

                <div class="e-sub-debt e-sub-default">
                    <div class="e-sub-subtitlebar e-sub-dai"></div>
                    <div class="e-sub-subtitle">
                        <table>
                            <tr>
                                <td>
                                    <div class="dhmq dai"></div>
                                </td>
                                <td>
                                    <div><span class="float-big"><%=PageHelper.SpliteInt(debit) %>.</span><span class="float-small"><%=PageHelper.SpliteFloat(debit) %></span></div>
                                </td>
                                <td>
                                    <div>借贷</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="e-sub-contitle">
                        <span>无债一身轻</span>
                    </div>
                    <div id="e-sub-cd-chart" class="e-sub-chart" style="height: 300px; display: block;">
                    </div>
                </div>

                <div class="e-sub-buy e-sub-default">
                    <div class="e-sub-subtitlebar e-sub-mai"></div>
                    <div class="e-sub-subtitle">
                        <table>
                            <tr>
                                <td>
                                    <div class="dhmq mai"></div>
                                </td>
                                <td>
                                    <div><span class="float-big"><%=PageHelper.SpliteInt(buy) %>.</span><span class="float-small"><%=PageHelper.SpliteFloat(buy) %></span></div>
                                </td>
                                <td>
                                    <div>购买</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="e-sub-contitle">
                        <span>购买</span>
                    </div>
                    <div id="e-sub-py-chart" class="e-sub-chart" style="height: 300px; display: block;">
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src="Js/echarts-plain.js"></script>
    <script type="text/javascript">
        //var mychart = echarts.init(document.getElementById("e-sub-ex-chart"));
        //var myoption = {
        //    title: {
        //        text: '未来一周气温变化',
        //        subtext: '纯属虚构'
        //    },
        //    tooltip: {
        //        trigger: 'axis'
        //    },
        //    legend: {
        //        data: ['最高气温', '最低气温']
        //    },
        //    toolbox: {
        //        show: true,
        //        feature: {
        //            mark: { show: false },
        //            dataView: { show: false, readOnly: true },
        //            magicType: { show: false, type: ['line', 'bar'] },
        //            restore: { show: false },
        //            saveAsImage: { show: false }
        //        }
        //    },
        //    calculable: true,
        //    xAxis: [
        //        {
        //            type: 'category',
        //            boundaryGap: false,
        //            data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
        //        }
        //    ],
        //    yAxis: [
        //        {
        //            type: 'value',
        //            axisLabel: {
        //                formatter: '{value} °C'
        //            }
        //        }
        //    ],
        //    series: [
        //        {
        //            name: '最高气温',
        //            type: 'line',
        //            data: [11, 11, 15, 13, 12, 13, 10],
        //            markPoint: {
        //                data: [
        //                    { type: 'max', name: '最大值' },
        //                    { type: 'min', name: '最小值' }
        //                ]
        //            },
        //            markLine: {
        //                data: [
        //                    { type: 'average', name: '平均值' }
        //                ]
        //            }
        //        },
        //        {
        //            name: '最低气温',
        //            type: 'line',
        //            data: [1, -2, 2, 5, 3, 2, 0],
        //            markPoint: {
        //                data: [
        //                    { name: '周最低', value: -2, xAxis: 1, yAxis: -1.5 }
        //                ]
        //            },
        //            markLine: {
        //                data: [
        //                    { type: 'average', name: '平均值' }
        //                ]
        //            }
        //        }
        //    ]
        //};
        //mychart.setOption(myoption);
        var exchart = echarts.init(document.getElementById("e-sub-ex-chart"));
        var inchart = echarts.init(document.getElementById("e-sub-in-chart"));
        var cdchart = echarts.init(document.getElementById("e-sub-cd-chart"));
        var pychart = echarts.init(document.getElementById("e-sub-py-chart"));
        $.get("ChartInfo.ashx", { type: "ex" }, function (data) {
            var myoption = eval("(" + data + ")");
            exchart.setOption(myoption);
        });
        $.get("ChartInfo.ashx", { type: "in" }, function (data) {
            var myoption = eval("(" + data + ")");
            inchart.setOption(myoption);
        });
        $.get("ChartInfo.ashx", { type: "cd" }, function (data) {
            var myoption = eval("(" + data + ")");
            cdchart.setOption(myoption);
        });
        $.get("ChartInfo.ashx", { type: "py" }, function (data) {
            var myoption = eval("(" + data + ")");
            pychart.setOption(myoption);
        });
    </script>
    <script>
        toolbar_index = 2;
    </script>
</asp:Content>

