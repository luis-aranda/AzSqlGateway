using System;
using System.Management.Automation;
using HtmlAgilityPack;
using System.Net;
using System.Net.Sockets;

namespace AzSqlGateway
{
    public class SqlGateway
    {
        public string Region { get; set; }
        public string[] IPAddress { get; set; }
        public string[] IPAddressSubnet { get; set; }

        public SqlGateway(string Region, string[] IPAddress, string[] IPAddressSubnet)
        {
            this.Region = Region;
            this.IPAddress = IPAddress;
            this.IPAddressSubnet = IPAddressSubnet;
        }
    } // end class SQLGateway

    [Cmdlet(VerbsData.Import, "AzSQLGateway")]
    [OutputType(typeof(SqlGateway))]
    public class ImportAzSQLGateway : Cmdlet
    {

        [Parameter()]
        public Uri Uri { get; set; } = new System.Uri("https://docs.microsoft.com/en-us/azure/azure-sql/database/connectivity-architecture");

        protected override void EndProcessing()
        {
            var web = new HtmlWeb();
            var doc = web.Load(Uri);
            var tables = doc.DocumentNode.SelectNodes("//table");
            var rows = tables[0].SelectNodes(".//tr");

            int rowindex = 0;
            int columns = 0;
            int tablerowindex = 0;

            String region = null;
            String[] ipAddress = null;
            String[] ipAddressSubnet = null;

            foreach (var row in rows)
            {
                // If this is the header row
                if (rowindex == 0)
                {
                    WriteDebug("Process table headers");
                    foreach (var cell in row.SelectNodes("th|td"))
                    {
                        WriteDebug(cell.InnerText.Trim());
                        columns++;
                    }

                    WriteDebug("Number of columns: " + columns);
                    columns--;
                }
                else
                {
                    WriteDebug("Process table content");

                    foreach (var cell in row.SelectNodes("th|td"))
                    {
                        WriteDebug("Content Table Column Index: " + tablerowindex.ToString());

                        switch (tablerowindex)
                        {
                            case 0:

                                WriteDebug("Region is: " + cell.InnerText.Trim());
                                region = cell.InnerText.Trim();
                                break;

                            case 1:

                                WriteDebug("Gateway IP Address is: " + cell.InnerText.Trim());
                                ipAddress = cell.InnerText.Replace(" ", "").Split(',');
                                break;

                            case 2:

                                WriteDebug("Gateway IP Address subnet is: " + cell.InnerText.Trim());
                                ipAddressSubnet = cell.InnerText.Replace(" ", "").Split(',');

                                var sqlgateway = new SqlGateway(region, ipAddress, ipAddressSubnet);
                                WriteObject(sqlgateway);

                                break;

                            default:
                                break;
                        }

                        // Reset the counter after processing a single row
                        tablerowindex = (tablerowindex >= columns) ? 0 : tablerowindex + 1;
                    }
                }

                rowindex++;

            } // end foreach

        } // end EndProcessing

    } // end GetAzSQLGateway

    [Cmdlet(VerbsCommon.Get, "AzSQLGateway")]
    [OutputType(typeof(SqlGateway))]
    public class GetAzSQLGateway : Cmdlet
    {
        [Parameter(ParameterSetName = "ByRegion", Position = 0)]
        [ValidateNotNullOrEmpty]
        public String Region { get; set; }

        protected override void ProcessRecord()
        {
            var result = new ImportAzSQLGateway().Invoke();
            if (this.Region == null)
            {
                foreach (var row in result)
                {
                    WriteObject(row);
                } // end foreach
            }
            else
            {
                foreach (var row in result)
                {
                    if (((AzSqlGateway.SqlGateway)row).Region == Region)
                    {
                        WriteObject(row);
                    }
                } // end foreach

            } //end else

        } //end ProcessRecord

    } // end Get-AzSQLGateway

    public class SqlGatewayTestResult
    {
        public string Region { get; set; }
        public string IpAddress { get; set; }
        public bool TcpTestSucceded { get; set; }

        public SqlGatewayTestResult(string Region, string IpAddress, bool TcpTestSucceded)
        {
            this.Region = Region;
            this.IpAddress = IpAddress;
            this.TcpTestSucceded = TcpTestSucceded;
        }
    }
    [Cmdlet(VerbsDiagnostic.Test, "AzSQLGateway")]
    [OutputType(typeof(SqlGatewayTestResult))]
    public class TestAzSQLGateway : PSCmdlet
    {
        [Parameter(ParameterSetName = "ByObject", ValueFromPipeline = true)]
        public SqlGateway SqlGateway { get; set; }

        protected override void ProcessRecord()
        {
            var ps = PowerShell.Create();
            WriteDebug("Processing Region " + SqlGateway.Region);

            if (ParameterSetName == "ByObject")
            {
                foreach (string ip in SqlGateway.IPAddress)
                {
                    bool TcpTestSucceded = true;

                    WriteDebug("Testing connectivity to Gateway IP: " + ip);

                    var ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 1433);
                    TcpClient client = new TcpClient();
                    try
                    {
                        client.Connect(ipEndPoint);
                    }
                    catch (System.Exception)
                    {
                        TcpTestSucceded = false;
                    }

                    var result = new SqlGatewayTestResult(this.SqlGateway.Region, ip, TcpTestSucceded);

                    WriteObject(result);
                } //end foreach

            } //end if

        } // end ProcessRecord

    } // end TestAzSQLGateway

} //end AzSqlGateway