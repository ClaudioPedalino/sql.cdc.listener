using System.ComponentModel.DataAnnotations;

public class MOCK_DATA
{
    [Key]
    public int Id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string Ip_address { get; set; }
    public string Btc_address { get; set; }
}