using ClosedXML.Excel;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.CompletedBuyerServices
{
    public class CompletedBuyersExportToExcel
    {
        private readonly IBuyerGetter<CompletedBuyerModel> _completedBuyersExport;

        public CompletedBuyersExportToExcel(IBuyerGetter<CompletedBuyerModel> completedBuyersExport)
        {
            _completedBuyersExport = completedBuyersExport;
        }

        public void ExportToExcelCompletedBuyers(string filePath)
        {
            var buyers = _completedBuyersExport.GetAll(); // Use GetAll() directly

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Completed Buyers");

                worksheet.Cell("A1").Value = "Id";
                worksheet.Cell("B1").Value = "First Name";
                worksheet.Cell("C1").Value = "Last Name";
                worksheet.Cell("D1").Value = "Cellphone Number";
                worksheet.Cell("E1").Value = "Email Adress";
                worksheet.Cell("F1").Value = "Date Time";
                worksheet.Cell("G1").Value = "Metric Amount";
                worksheet.Cell("H1").Value = "Metric Price";
                worksheet.Cell("I1").Value = "Gross Income";

                worksheet.Column(6).Style.DateFormat.Format = "dd-MM-yyyy HH:mm";
                worksheet.Column(7).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(8).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(9).Style.NumberFormat.Format = "#,##0.00";

                int row = 2;
                foreach (var buyer in buyers)
                {
                    worksheet.Cell(row, 1).Value = buyer.Id;
                    worksheet.Cell(row, 2).Value = buyer.FirstName;
                    worksheet.Cell(row, 3).Value = buyer.LastName;
                    worksheet.Cell(row, 4).Value = buyer.CellphoneNumber;
                    worksheet.Cell(row, 5).Value = buyer.EmailAddress;
                    worksheet.Cell(row, 6).Value = buyer.DateTime;
                    worksheet.Cell(row, 7).Value = buyer.MetricAmount;
                    worksheet.Cell(row, 8).Value = buyer.MetricPrice;
                    worksheet.Cell(row, 9).Value = buyer.GrossIncome;

                    row++;
                }

                workbook.SaveAs(filePath);
            }
        }
    }
}
