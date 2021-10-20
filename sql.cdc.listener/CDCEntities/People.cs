using sql.cdc.listener.Config;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql.cdc.listener.CDCTables
{
    [Table($"{nameof(People)}{Consts.Postfix}", Schema = Consts.CDCSchema)]
    public class People : BaseEntityCDC
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IsDelete { get; set; }
    }
}
