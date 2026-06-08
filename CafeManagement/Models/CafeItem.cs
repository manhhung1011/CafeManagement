using System.ComponentModel.DataAnnotations;

namespace CafeManagement.Models
{
    public class CafeItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên món không được để trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Loại món không được để trống")]
        public string Category { get; set; }

        [Range(1, 100000000, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        [Range(0, 999, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string Description { get; set; }
    }
}