using _12_08.Dtos;
using Dapper;
using Microsoft.Data.SqlClient;

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
    }
}
