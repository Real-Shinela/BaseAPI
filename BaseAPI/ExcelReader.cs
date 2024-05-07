using ExcelDataReader;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using BaseAPI.Structure;

namespace BaseAPI.Excel
{
    public class ExcelReader
    {
        public List<ResponseStructure> ReadData(string filePath)
        {
            List<ResponseStructure> responses = new List<ResponseStructure>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            {
                DataSet dataSet = reader.AsDataSet();
                DataTable dataTable = dataSet.Tables[0];  

                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    DataRow? row = dataTable.Rows[i];
                    ResponseStructure? response = new()
                    {
                        Key = i.ToString(),
                        Value = row[1].ToString()
                    };
                    responses.Add(response);
                }
            }
            return responses;
        }
    }
}