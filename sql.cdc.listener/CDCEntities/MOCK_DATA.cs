using sql.cdc.listener.Config;
using System.ComponentModel.DataAnnotations.Schema;
namespace sql.cdc.listener.CDCTables
{
    [Table($"{nameof(MOCK_DATA)}{Consts.Postfix}", Schema = Consts.CDCSchema)]
    public class MOCK_DATA : BaseEntityCDC
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ip_address { get; set; }
        public string Btc_address { get; set; }
    }
}
