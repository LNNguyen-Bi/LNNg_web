using System.ComponentModel.DataAnnotations;

public class TaiKhoanViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Username { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }

    public string FullName { get; set; }

    public int Age { get; set; }

    public string PasswordHash { get; set; }
}