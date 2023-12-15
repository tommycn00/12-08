using _12_08.Dtos;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Any;
using System.Runtime.InteropServices;

namespace _12_08.Repository
{
    public class StockRepository
    {
        private readonly string connstr = @"
Server=127.0.0.1;Database=study;User ID=sa;Password=1234;TrustServerCertificate=true
";
        public IEnumerable<StockDto> GetAll()
        {
            string sql = @"
SELECT A.BARCODE, A.QTY, B.NAME FROM INVENTORY A
JOIN ITEM B ON A.BARCODE = B.BARCODE
";
            using(var conn = new SqlConnection(connstr))
            {
                var result = conn.Query<StockDto>(sql);
                return result;
            }
        }

        public IEnumerable<StockDto> GetCond(StockDto inpara) 
        {
            string sql = $@"
SELECT A.BARCODE, A.QTY, B.NAME FROM INVENTORY A
JOIN ITEM B ON A.BARCODE = B.BARCODE
{CreateWhereCondition(inpara)}
";
            using (var conn = new SqlConnection(connstr))
            {
                var result = conn.Query<StockDto>(sql, inpara); 
                return result;
            }
        }

        private object CreateWhereCondition(StockDto inpara)
        {
            if (inpara == null) return "";

            var list = new List<string>();

            if(!string.IsNullOrEmpty(inpara.Barcode))
            {
                list.Add("A.BARCODE = @barcode");
            }
            if (!string.IsNullOrEmpty(inpara.Qty.ToString()))
            {
                list.Add("A.QTY = @qty");
            }

            return list.Any() ?
                $"WHERE {string.Join(" And ", list)}" : "";
        }

        public StockDto updStock(StockDto inpara)
        {
            
        }
    }
}
