using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace TryNextPostWebApi.Services
{
    public class ExcelLoginLogger
    {
        private readonly string _folderPath;

        public ExcelLoginLogger()
        {
            _folderPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "UserLogs");
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            ExcelPackage.License.SetNonCommercialPersonal("AnyName");
        }
        //===============start login page log save save data into excel ========================================
        public async Task LogAsync(string userName, string email, string message)
        {
            string fileName = $"UserLog_{DateTime.UtcNow:yyyyMMdd}.xlsx";
            string filePath = Path.Combine(_folderPath, fileName);
            FileInfo file = new FileInfo(filePath);
            using var package = new ExcelPackage(file);

            ExcelWorksheet sheet;

            bool isNewFile = !file.Exists;

            if (isNewFile)
            {
                sheet = package.Workbook.Worksheets.Add("Logs");

                // Headers
                sheet.Cells[1, 1].Value = "UserName";
                sheet.Cells[1, 2].Value = "Email";
                sheet.Cells[1, 3].Value = "IP Address";
                sheet.Cells[1, 4].Value = "MAC Address";
                sheet.Cells[1, 5].Value = "Login Time";
                sheet.Cells[1, 6].Value = "Logout Time";
                sheet.Cells[1, 7].Value = "Message";

                // Header Style
                using (var header = sheet.Cells[1, 1, 1, 7])
                {
                    header.Style.Font.Bold = true;
                    header.Style.Font.Color.SetColor(Color.White);
                    header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    header.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(68, 114, 196));
                    header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                sheet.View.FreezePanes(2, 1);
            }
            else
            {
                sheet = package.Workbook.Worksheets["Logs"];
            }

            int nextRow = (sheet.Dimension?.Rows ?? 1) + 1;

            // Data
            sheet.Cells[nextRow, 1].Value = userName;
            sheet.Cells[nextRow, 2].Value = email;
            sheet.Cells[nextRow, 3].Value = GetIPv4Address();
            sheet.Cells[nextRow, 4].Value = GetMacAddress();
            sheet.Cells[nextRow, 5].Value = DateTime.Now;
            sheet.Cells[nextRow, 6].Value = null;
            sheet.Cells[nextRow, 7].Value = message;

            // Date Format
            sheet.Column(5).Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
            sheet.Column(6).Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";

            // Entire data range
            var dataRange = sheet.Cells[1, 1, sheet.Dimension.Rows, 7];

            // Borders
            dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            // Remove existing table before recreating
            if (sheet.Tables.Count > 0)
            {
                var existingTable = sheet.Tables.FirstOrDefault();
                if (existingTable != null)
                {
                    sheet.Tables.Delete(existingTable.Name);
                }
            }

            // Create Excel Table with filters
            var tableRange = sheet.Cells[1, 1, sheet.Dimension.Rows, 7];
            var table = sheet.Tables.Add(tableRange, "UserLogsTable");
            table.TableStyle = TableStyles.Medium2;

            // Auto Fit Columns
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            await package.SaveAsync();
        }
        //======================end login page log save data into excel =======================
        //==========================start log out page save data into excel sheet===================
        public async Task UpdateLogoutTimeAsync(string email)
        {
            string fileName = $"UserLog_{DateTime.UtcNow:yyyyMMdd}.xlsx";
            string filePath = Path.Combine(_folderPath, fileName);

            FileInfo file = new FileInfo(filePath);

            if (!file.Exists)
                return;

            using var package = new ExcelPackage(file);
            var sheet = package.Workbook.Worksheets["Logs"];

            if (sheet?.Dimension == null)
                return;

            int rows = sheet.Dimension.Rows;

            // Find last row for this user (reverse loop)
            for (int row = rows; row >= 2; row--)
            {
                var emailInSheet = sheet.Cells[row, 2].Value?.ToString();

                if (emailInSheet == email)
                {
                    sheet.Cells[row, 6].Value = DateTime.Now; // Logout Time column
                    break;
                }
            }

            await package.SaveAsync();
        }
        //========================end start log out page save data into excel sheet==========================
        private string GetIPv4Address()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    var ip = ni.GetIPProperties()
                        .UnicastAddresses
                        .FirstOrDefault(a =>
                            a.Address.AddressFamily == AddressFamily.InterNetwork);

                    if (ip != null)
                    {
                        return ip.Address.ToString();
                    }
                }
            }

            return "N/A";
        }

        private string GetMacAddress()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .FirstOrDefault(n => n.OperationalStatus == OperationalStatus.Up)?
                .GetPhysicalAddress()
                .ToString() ?? "N/A";
        }
    }
}