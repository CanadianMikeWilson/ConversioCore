using System.Threading.Tasks;

namespace ConversioCore
{
    public interface IReceiptService
    {
        Task<bool> SendReceiptAsync(SendReceiptRequest receiptRequest);
    }
}