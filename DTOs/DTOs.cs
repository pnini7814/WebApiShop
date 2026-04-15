using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public record UserDTO(int UserId,[EmailAddress][Required]string UserName, string Password ,[MinLength(5)]string FirstName,string LastName);
    public record ProductDTO(int ProductId, string ProductName, decimal Price, string CategoryName,int CategoryId, string Description);
    public record OrderDTO(int OrderId, DateOnly OrderDate, decimal OrderSum, int UserId, ICollection<OrderItemDTO> OrderItems);
    public record OrderItemDTO(int OrderItemId,int ProductId, int OrderId, int Quantity);
    public record CategoryDTO(int CategoryId, string CategoryName);
    public record LoginUserDTO([EmailAddress][Required]string UserName, [Required]string Password);
    public record PageResponsDTO(IEnumerable<ProductDTO>items,int Page,int size ,int total,int hasNext,int hasPrevious );



}
