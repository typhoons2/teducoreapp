using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Domain.Interfaces;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{		
	[Table("Bills")]
    public class Bill : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Bill() { }

        public Bill(string customerName, string customerAddress, string customerMobile, string customerMessage, BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public Bill(int id, string customerName, string customerAddress, string customerMobile, string customerMessage, BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }
        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }

        // Địa chỉ giao hàng của khách hàng
        [Required]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        // Số điện thoại của khách hàng
        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        // Tin nhắn bổ sung từ khách hàng
        [Required]
        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        // Phương thức thanh toán (tiền mặt, thẻ tín dụng, v.v.)
        public PaymentMethod PaymentMethod { set; get; }

        // Trạng thái hiện tại của hóa đơn (đang chờ, hoàn thành, v.v.)
        public BillStatus BillStatus { set; get; }

        // Triển khai giao diện IDateTracking
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        // Triển khai giao diện ISwitchable
        [DefaultValue(Status.Active)]
        public Status Status { set; get; } = Status.Active;

        // Khóa ngoại đến bảng người dùng
        public Guid CustomerId { set; get; }

        // Thuộc tính điều hướng đến người dùng
        [ForeignKey("CustomerId")]
        public virtual AppUser User { set; get; }

        // Tập hợp các chi tiết hóa đơn (sản phẩm trong hóa đơn này)
        public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}
