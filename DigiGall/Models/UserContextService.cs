namespace DigiGall.Models;

public class UserContextService
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string House { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public int Galleon { get; set; } = default!;
    public int Rank { get; set; } = 1;
}