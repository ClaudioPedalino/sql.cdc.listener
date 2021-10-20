using System.ComponentModel.DataAnnotations.Schema;

namespace sql.cdc.listener.CDCTables
{
    public class BaseEntityCDC
    {
        [Column("__$start_lsn")] public byte[] Start_lsn { get; set; }
        [Column("__$end_lsn")] public byte[] End_lsn { get; set; }
        [Column("__$seqval")] public byte[] Seqval { get; set; }
        [Column("__$operation")] public CDCOperation Operation { get; set; }
        [Column("__$update_mask")] public byte[] Update_mask { get; set; }
        [Column("__$command_id")] public int Command_id { get; set; }
    }

    public enum CDCOperation
    {
        Delete = 1,
        Insert = 2,
        UpdateBefore = 3,
        UpdateAfter = 4,
    }
}