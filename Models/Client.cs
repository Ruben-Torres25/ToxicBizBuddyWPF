namespace ToxicBizBuddyWPF.Models;

public class Client
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Pedidos { get; set; }
    public string Saldo { get; set; } = string.Empty;
    public string UltimoPedidoFecha { get; set; } = string.Empty;
}
